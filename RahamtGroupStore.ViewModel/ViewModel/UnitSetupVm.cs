using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class UnitSetupVm : GenericViewModel<UnitInformation>
    {
        public UnitSetupVm()
            : base("Unit Setup")
        {
            InitialData();
        }


        public override void UpdateCommandExecute(UnitInformation entity)
        {
            if (DataRepository.IsEntityExists(x => x.UnitName.Equals(entity.UnitName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(string.Format(ErrorMessage[16], "Unit Name"), SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                DataRepository.ClearChanges(entity);
                return;
            }
            base.UpdateCommandExecute(entity);
        }

        public override bool CommandCanExecute(UnitInformation entity)
        {
            try
            {
                return !String.IsNullOrEmpty(entity.UnitName);
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Helper

        private async void InitialData()
        {
            IsBusy = true;
            await Task.Factory.StartNew(() =>
                {
                    ItemCollection =
                        new ObservableCollection<UnitInformation>(
                            DataRepository.GetAll().OrderBy(x => x.UnitName));
                    IsBusy = false;
                });
        }

        #endregion
    }
}
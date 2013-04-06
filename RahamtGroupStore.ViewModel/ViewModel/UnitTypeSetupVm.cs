using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class UnitTypeSetupVm : GenericViewModel<UnitType>
    {
        public UnitTypeSetupVm()
            : base("Unit Type Setup")
        {
            InitialData();
        }

        public override void UpdateCommandExecute(UnitType entity)
        {
            if (DataRepository.IsEntityExists(x => x.UnitName.Equals(entity.UnitName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(string.Format(ErrorMessage[16], "Unit Type"), SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                DataRepository.ClearChanges(entity);
                return;
            }
            base.UpdateCommandExecute(entity);
        }

        public override bool CommandCanExecute(UnitType entity)
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
                                                ItemCollection = new ObservableCollection<UnitType>(DataRepository.GetAll().OrderBy(x => x.UnitName));
                                                IsBusy = false;
                                            });
        }

        #endregion
    }
}
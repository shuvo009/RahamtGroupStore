using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class OrdinaryTypeVm : GenericViewModel<OrdinaryType>
    {
        public OrdinaryTypeVm() : base("Type Setup")
        {
            InitialData();
        }


        public override void UpdateCommandExecute(OrdinaryType entity)
        {
            if (DataRepository.IsEntityExists(x => x.OrdType.Equals(entity.OrdType, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(string.Format(ErrorMessage[16], "Type"), SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                DataRepository.ClearChanges(entity);
                return;
            }
            base.UpdateCommandExecute(entity);
        }

        public override bool CommandCanExecute(OrdinaryType entity)
        {
            try
            {
                return !String.IsNullOrEmpty(entity.OrdType);
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
            await Task.Factory.StartNew(
                () =>
                    {
                        ItemCollection =
                            new ObservableCollection<OrdinaryType>(
                                DataRepository.GetAll().OrderBy(x => x.OrdType));
                        IsBusy = false;
                    });
        }

        #endregion
    }
}
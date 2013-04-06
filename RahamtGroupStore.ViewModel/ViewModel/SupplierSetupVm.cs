using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;
using RahamtGroupStore.ViewModel.Methods;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class SupplierSetupVm : GenericViewModel<SupplierInformation>
    {
        public SupplierSetupVm()
            : base("Supplier Setup")
        {
            InitialData();
        }


        public override void UpdateCommandExecute(SupplierInformation entity)
        {
            if (CheckEntityExists(entity))
            {
                MessageBox.Show(string.Format(ErrorMessage[16], "Supplier Name"), SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                DataRepository.ClearChanges(entity);
                return;
            }
            base.UpdateCommandExecute(entity);
        }

        public override bool CommandCanExecute(SupplierInformation entity)
        {
            try
            {
                return
                    !(String.IsNullOrEmpty(entity.Name) ||
                      String.IsNullOrEmpty(entity.Mobile) ||
                      String.IsNullOrEmpty(entity.Address));
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Helper

        private bool CheckEntityExists(SupplierInformation entity)
        {
            return (DataRepository.IsEntityExists(x => x.Name.Equals(entity.Name, StringComparison.OrdinalIgnoreCase)) && entity.IsNew())
                   || DataRepository.IsEntityExists(x => x.Name.Equals(entity.Name, StringComparison.OrdinalIgnoreCase) && x.Id != entity.Id);
        }


        private async void InitialData()
        {
            IsBusy = true;
            await Task.Factory.StartNew(() =>
                {
                    ItemCollection =
                        new ObservableCollection<SupplierInformation>(
                            DataRepository.GetAll().OrderBy(x => x.Name));
                    IsBusy = false;
                });
        }

        #endregion
    }
}
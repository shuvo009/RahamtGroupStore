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
    public class RepairCompanyVm : GenericViewModel<RepairCompaneyInformation>
    {
        public RepairCompanyVm()
            : base("Repair Company Setup")
        {
            InitialData();
        }


        public override void UpdateCommandExecute(RepairCompaneyInformation entity)
        {
            if (CheckItemExists(entity))
            {
                MessageBox.Show(string.Format(ErrorMessage[16], "Company Name"), SoftwareName, MessageBoxButton.OK, MessageBoxImage.Stop);
                DataRepository.ClearChanges(entity);
                return;
            }
            base.UpdateCommandExecute(entity);
        }

        public override bool CommandCanExecute(RepairCompaneyInformation entity)
        {
            try
            {
                return
                    !(String.IsNullOrEmpty(entity.Name) ||
                      String.IsNullOrEmpty(entity.Address));
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Helper

        private bool CheckItemExists(RepairCompaneyInformation entity)
        {
            return (DataRepository.IsEntityExists(x => x.Name.Equals(entity.Name, StringComparison.OrdinalIgnoreCase)) && entity.IsNew())
                   || DataRepository.IsEntityExists(x => x.Name.Equals(entity.Name, StringComparison.OrdinalIgnoreCase) && x.Id != entity.Id);
        }


        private async void InitialData()
        {
            IsBusy = true;
            await Task.Factory.StartNew(
                () =>
                    {
                        ItemCollection =
                            new ObservableCollection<RepairCompaneyInformation>(
                                DataRepository.GetAll().OrderBy(x => x.Name));
                        IsBusy = false;
                    });
        }

        #endregion
    }
}
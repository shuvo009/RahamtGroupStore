using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using RahamtGroupStore.Model;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class RepairCompanyListVm : GenericListAndPrint<RepairCompaneyInformation>
    {
        public RepairCompanyListVm()
            : base("Repair Company List")
        {
            InitialData();
        }

        public override bool CommandCanExecute(RepairCompaneyInformation entity)
        {
            throw new NotImplementedException();
        }

        #region Helper
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
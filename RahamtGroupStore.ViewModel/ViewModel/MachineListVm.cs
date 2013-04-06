using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class MachineListVm : GenericListAndPrint<MachineInformation>
    {
        public MachineListVm()
            : base("Machine List")
        {
            InitialData();
        }


        public override bool CommandCanExecute(MachineInformation entity)
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
                            new ObservableCollection<MachineInformation>(DataRepository.GetAll().OrderBy(x => x.Name));
                        IsBusy = false;
                    }
                );
        }

        #endregion
    }
}
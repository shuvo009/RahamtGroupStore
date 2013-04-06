using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class SparesListVm : GenericListAndPrint<SparesInformation>
    {
        public SparesListVm()
            : base("Spares List")
        {
            InitialData();
            Messenger.Default.Register(this,
                                       new Action<Int64>(
                                           machinId => ItemCollection = new ObservableCollection<SparesInformation>
                                                                            (DataRepository.Search(x => x.MachineInformation.Id == machinId))));
        }


        public override bool CommandCanExecute(SparesInformation entity)
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
                        new ObservableCollection<SparesInformation>(
                            DataRepository.GetAll().OrderBy(x => x.PartName));
                    IsBusy = false;
                });
        }

        #endregion
    }
}
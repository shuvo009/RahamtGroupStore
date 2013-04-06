using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class FaultyListVm : SearchWithPrint<MachineBreakdownInformation>
    {
        private DateTime _fistDate;

        public FaultyListVm()
            : base("Faulty List")
        {
            InitialData();
            FistDate = DateTime.Today;
        }

        public DateTime FistDate
        {
            get { return _fistDate; }
            set
            {
                _fistDate = value;
                OnPeroertyChange("FistDate");
            }
        }


        public override bool CommandCanExecute(MachineBreakdownInformation entity)
        {
            throw new NotImplementedException();
        }

        protected override async void SearchCommandExecute(MachineBreakdownInformation entity)
        {
            try
            {
                IsBusy = true;
                await Task.Factory.StartNew(() =>
                                                {
                                                    ItemCollection =
                                                        new ObservableCollection<MachineBreakdownInformation>(
                                                            DataRepository.Search(
                                                                x => x.EntryDate >= FistDate && x.EntryDate <= SecondDate).OrderBy(
                                                                    x => x.MachineInformation.Name));
                                                    IsBusy = false;
                                                });
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[15], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override bool SearchCommandCanExecute(MachineBreakdownInformation entity)
        {
            return true;
        }

        #region Helper

        private async void InitialData()
        {
            IsBusy = true;
            await Task.Factory.StartNew(
                () =>
                    {
                        ItemCollection = new ObservableCollection<MachineBreakdownInformation>(DataRepository.GetAll().OrderBy(x => x.MachineInformation.Name));
                        IsBusy = false;
                    });
        }

        #endregion
    }
}
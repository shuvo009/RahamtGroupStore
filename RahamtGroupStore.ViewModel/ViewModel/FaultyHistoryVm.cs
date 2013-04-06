using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class FaultyHistoryVm : SearchWithPrint<FaultSpareHistory>
    {
        private DateTime _fistDate;

        public FaultyHistoryVm()
            : base("Faulty History")
        {
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

        public override bool CommandCanExecute(FaultSpareHistory entity)
        {
            throw new NotImplementedException();
        }

        protected override async void SearchCommandExecute(FaultSpareHistory entity)
        {
            try
            {
                IsBusy = true;
                await Task.Factory.StartNew(() =>
                                                {
                                                    ItemCollection =
                                                        new ObservableCollection<FaultSpareHistory>(
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

        protected override bool SearchCommandCanExecute(FaultSpareHistory entity)
        {
            return true;
        }
    }
}
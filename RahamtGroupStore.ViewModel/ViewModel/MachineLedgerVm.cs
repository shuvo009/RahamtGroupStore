using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class MachineLedgerVm : SearchWithPrint<IssueSpareParts>
    {
        public MachineLedgerVm() : base("Machine Ledger")
        {
            Messenger.Default.Register(this, new Action<MachineInformation>(machineInfo =>
                                                                                {
                                                                                    SelectedItem.
                                                                                        MachineInformation
                                                                                        = DataRepository.GetMachineInfoById(machineInfo.Id);
                                                                                }));
        }

        public override bool CommandCanExecute(IssueSpareParts entity)
        {
            throw new NotImplementedException();
        }

        protected override async void SearchCommandExecute(IssueSpareParts entity)
        {
            try
            {
                IsBusy = true;
                await Task.Factory.StartNew(() =>
                                                {
                                                    if (entity.MachineInformation != null)
                                                    {
                                                        ItemCollection =
                                                            new ObservableCollection<IssueSpareParts>(DataRepository.Search
                                                                                                          (
                                                                                                              x =>
                                                                                                              x.MachineInformation.Id ==
                                                                                                              entity.MachineInformation.Id &&
                                                                                                              (x.EntryDate >= entity.EntryDate &&
                                                                                                               x.EntryDate <= SecondDate)).OrderByDescending((x => x.EntryDate)));
                                                    }
                                                    else
                                                    {
                                                        ItemCollection =
                                                            new ObservableCollection<IssueSpareParts>(DataRepository.Search
                                                                                                          (
                                                                                                              x =>
                                                                                                              (x.EntryDate >=
                                                                                                               entity.EntryDate &&
                                                                                                               x.EntryDate <= SecondDate) && x.MachineInformation != null).OrderByDescending(x => x.EntryDate));
                                                    }
                                                    IsBusy = false;
                                                });
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[15], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override bool SearchCommandCanExecute(IssueSpareParts entity)
        {
            return true;
        }
    }
}
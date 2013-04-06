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
    public class SparesHistoryVm : SearchWithPrint<MachineLedger>
    {
        public SparesHistoryVm()
            : base("Spares History")
        {
            Messenger.Default.Register(this, new Action<MachineInformation>(machineInfo =>
                                                                                {
                                                                                    SelectedItem.MachineInformation
                                                                                        = DataRepository.GetMachineInfoById(machineInfo.Id);
                                                                                }));
        }


        protected override async void SearchCommandExecute(MachineLedger entity)
        {
            try
            {
                IsBusy = true;
                await Task.Factory.StartNew(() =>
                {
                    if (entity.MachineInformation != null)
                    {
                        ItemCollection =
                            new ObservableCollection<MachineLedger>(DataRepository.Search
                                                                        (
                                                                            x => x.MachineInformation.Id == entity.MachineInformation.Id &&
                                                                                 (x.EntryDate >= entity.EntryDate && x.EntryDate <= SecondDate))
                                                                        .OrderByDescending((x => x.EntryDate)));
                    }
                    else
                    {
                        ItemCollection =
                            new ObservableCollection<MachineLedger>(DataRepository.Search
                                                                        (
                                                                            x => (x.EntryDate >= entity.EntryDate && x.EntryDate <= SecondDate))
                                                                        .OrderByDescending(x => x.EntryDate));
                        IsBusy = false;
                    }
                });
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[15], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override bool SearchCommandCanExecute(MachineLedger entity)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override void ResetCommandExecute(MachineLedger entity)
        {
            ItemCollection = null;
            SecondDate = DateTime.Today;
            entity.MachineInformation = null;
            base.ResetCommandExecute(entity);
        }

        public override bool CommandCanExecute(MachineLedger entity)
        {
            throw new NotImplementedException();
        }
    }
}
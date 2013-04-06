using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;
using RahamtGroupStore.ViewModel.Methods;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class MachineBreakdownVm : GenericViewModel<MachineBreakdownInformation>
    {
        private ObservableCollection<BreakdownCause> _breakdownCauses;
        private ObservableCollection<BreakdownType> _breakdownTypes;
        private ObservableCollection<OrdinaryType> _ordinaryTypes;

        #region Propertys

        public ObservableCollection<BreakdownType> BreakdownTypes
        {
            get { return _breakdownTypes; }
            private set
            {
                _breakdownTypes = value;
                OnPeroertyChange("BreakdownTypes");
            }
        }

        public ObservableCollection<BreakdownCause> BreakdownCauses
        {
            get { return _breakdownCauses; }
            private set
            {
                _breakdownCauses = value;
                OnPeroertyChange("BreakdownCauses");
            }
        }

        public ObservableCollection<OrdinaryType> OrdinaryTypes
        {
            get { return _ordinaryTypes; }
            private set
            {
                _ordinaryTypes = value;
                OnPeroertyChange("OrdinaryTypes");
            }
        }

        #endregion

        public MachineBreakdownVm()
            : base("Machine Breakdown")
        {
            InitialData();

            BrowseImage = new RelayCommand<MachineBreakdownInformation>(BrowseCommandExecute);
            Messenger.Default.Register(this, new Action<MachineInformation>(machinInfo =>
                                                                                {
                                                                                    SelectedItem.
                                                                                        MachineInformation
                                                                                        = DataRepository.GetMachineInfoById(machinInfo.Id);
                                                                                }));
            Messenger.Default.Register(this, new Action<SparesInformation>(spareInfo =>
                                                                               {
                                                                                   SelectedItem.
                                                                                       SparesInformation
                                                                                       = DataRepository.GetSparesInfoById(spareInfo.Id);
                                                                               }));
        }

        public RelayCommand<MachineBreakdownInformation> BrowseImage { get; set; }


        private void BrowseCommandExecute(MachineBreakdownInformation machineBreakdownInformation)
        {
            try
            {
                machineBreakdownInformation.Image = new MiraculousMethods().SelectImageFromFile();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[6], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void UpdateCommandExecute(MachineBreakdownInformation entity)
        {
            DataRepository.AddToFaultHistory(entity);
            base.UpdateCommandExecute(entity);
        }


        public override void ResetCommandExecute(MachineBreakdownInformation entity)
        {
            entity.MachineInformation = null;
            entity.OrdinaryType = null;
            entity.SparesInformation = null;
            entity.BreakdownCause = null;
            entity.BreakdownType = null;
            entity.Image = null;
            base.ResetCommandExecute(entity);
        }

        public override bool CommandCanExecute(MachineBreakdownInformation entity)
        {
            try
            {
                return !(String.IsNullOrEmpty(entity.ReportedBy) ||
                         String.IsNullOrEmpty(entity.ProblemDescription) ||
                         String.IsNullOrEmpty(entity.ActionTaken));
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
            await Task.Factory.StartNew(() =>
                                            {
                                                ItemCollection =
                                                    new ObservableCollection<MachineBreakdownInformation>(
                                                        DataRepository.GetAll().OrderByDescending(
                                                            x => x.EntryDate));

                                                BreakdownTypes =
                                                    new ObservableCollection<BreakdownType>(DataRepository.GetBreakdownTypes());

                                                BreakdownCauses =
                                                    new ObservableCollection<BreakdownCause>(DataRepository.GetBreakdownCauses());

                                                OrdinaryTypes =
                                                    new ObservableCollection<OrdinaryType>(DataRepository.GetOrdinaryTypes());
                                                IsBusy = false;
                                            });
        }

        #endregion
    }
}
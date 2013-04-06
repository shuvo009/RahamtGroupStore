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
    public class SpareSetupVm : GenericViewModel<SparesInformation>
    {
        #region Private Variable

        private ObservableCollection<UnitInformation> _unitInformations;
        private ObservableCollection<UnitType> _unitTYpes;

        #endregion

        public SpareSetupVm()
            : base("Spare Setup")
        {
            InitialData();
            Messenger.Default.Register(this, new Action<MachineInformation>(machinnInfo =>
                                                                                {
                                                                                    MachineInformation mInfo = DataRepository.GetMachineInfoById(machinnInfo.Id);
                                                                                    SelectedItem.MachineInformation = mInfo;
                                                                                    SelectedItem.UnitInformation = mInfo.UnitInformation;
                                                                                    SelectedItem.SectionInformation = mInfo.SectionInformation;
                                                                                }));
        }


        public ObservableCollection<UnitInformation> UnitInformations
        {
            get { return _unitInformations; }
            set
            {
                _unitInformations = value;
                OnPeroertyChange("UnitInformations");
            }
        }


        public ObservableCollection<UnitType> UnitTypes
        {
            get { return _unitTYpes; }
            set
            {
                _unitTYpes = value;
                OnPeroertyChange("UnitTypes");
            }
        }

        public override void ResetCommandExecute(SparesInformation entity)
        {
            entity.MachineInformation = null;
            entity.UnitInformation = null;
            entity.SectionInformation = null;
            base.ResetCommandExecute(entity);
        }

        public override void UpdateCommandExecute(SparesInformation entity)
        {
            if (CheckItemExists(entity))
            {
                MessageBox.Show(string.Format(ErrorMessage[16], "Part No"), SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                DataRepository.ClearChanges(entity);
                return;
            }
            base.UpdateCommandExecute(entity);
        }

        public override bool CommandCanExecute(SparesInformation entity)
        {
            try
            {
                return !(String.IsNullOrEmpty(entity.PartName) ||
                         String.IsNullOrEmpty(entity.Partno));
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
            await Task.Factory.StartNew(
                () =>
                {
                    ItemCollection =
                        new ObservableCollection<SparesInformation>(
                            DataRepository.GetAll().OrderBy(x => x.PartName));
                    UnitInformations = new ObservableCollection<UnitInformation>(DataRepository.GetUnits());
                    UnitTypes = new ObservableCollection<UnitType>(DataRepository.GetUnitTyes());
                    IsBusy = false;
                });
        }

        private bool CheckItemExists(SparesInformation entity)
        {
            return (DataRepository.IsEntityExists(x => x.Partno.Equals(entity.Partno, StringComparison.OrdinalIgnoreCase)
                                                       && x.PartName.Equals(entity.PartName, StringComparison.OrdinalIgnoreCase)
                                                       && x.UnitInformation.UnitName.Equals(entity.UnitInformation.UnitName, StringComparison.OrdinalIgnoreCase)
                                                       && x.SectionInformation.SectionName.Equals(entity.SectionInformation.SectionName, StringComparison.OrdinalIgnoreCase))
                    && entity.IsNew())
                   || (DataRepository.IsEntityExists(x => x.UnitInformation.UnitName.Equals(entity.UnitInformation.UnitName, StringComparison.OrdinalIgnoreCase)
                                                          && x.SectionInformation.SectionName.Equals(entity.SectionInformation.SectionName, StringComparison.OrdinalIgnoreCase)
                                                          && x.Id != entity.Id
                                                          && x.PartName.Equals(entity.PartName, StringComparison.OrdinalIgnoreCase)
                                                          && x.Partno.Equals(entity.Partno, StringComparison.OrdinalIgnoreCase))
                       && !entity.IsNew());
        }

        #endregion
    }
}
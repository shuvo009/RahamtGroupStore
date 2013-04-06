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
    public class MachineInstallationVm : GenericViewModel<MachineInformation>
    {
        private ObservableCollection<UnitInformation> _unitInformations;

        public MachineInstallationVm()
            : base("Machine Installation")
        {
            InitialData();
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


        public override void UpdateCommandExecute(MachineInformation entity)
        {
            if (CheckItemExists(entity))
            {
                MessageBox.Show(string.Format(ErrorMessage[16], "Machine Name"), SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                DataRepository.ClearChanges(entity);
                return;
            }
            base.UpdateCommandExecute(entity);
        }


        public override bool CommandCanExecute(MachineInformation entity)
        {
            try
            {
                return !(String.IsNullOrEmpty(entity.Name) ||
                         String.IsNullOrEmpty(entity.MadeBy) ||
                         String.IsNullOrEmpty(entity.Origin) ||
                         String.IsNullOrEmpty(entity.McSerialNo) ||
                         String.IsNullOrEmpty(entity.Model) ||
                         entity.McQuentity <= 0 ||
                         String.IsNullOrEmpty(entity.Delivery));
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Helper

        private bool CheckItemExists(MachineInformation entity)
        {
            return (DataRepository.IsEntityExists(x => x.Name.Equals(entity.Name, StringComparison.OrdinalIgnoreCase) && x.UnitInformation.UnitName.Equals(entity.UnitInformation.UnitName, StringComparison.OrdinalIgnoreCase)
                                                       && x.SectionInformation.SectionName.Equals(entity.SectionInformation.SectionName, StringComparison.OrdinalIgnoreCase))
                    && entity.IsNew())
                   || (DataRepository.IsEntityExists(x => x.UnitInformation.UnitName.Equals(entity.UnitInformation.UnitName, StringComparison.OrdinalIgnoreCase)
                                                          && x.SectionInformation.SectionName.Equals(entity.SectionInformation.SectionName, StringComparison.OrdinalIgnoreCase) && x.Id != entity.Id && x.Name.Equals(entity.Name, StringComparison.InvariantCultureIgnoreCase))
                       && !entity.IsNew());
        }

        private async void InitialData()
        {
            IsBusy = true;
            await Task.Factory.StartNew(() =>
                                            {
                                                ItemCollection =
                                                    new ObservableCollection<MachineInformation>(
                                                        DataRepository.GetAll().OrderBy(x => x.Name));
                                                UnitInformations =
                                                    new ObservableCollection<UnitInformation>(DataRepository.GetUnits());
                                                IsBusy = false;
                                            });
        }

        #endregion
    }
}
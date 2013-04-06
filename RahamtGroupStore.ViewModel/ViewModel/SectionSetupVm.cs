using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class SectionSetupVm : GenericViewModel<SectionInformation>
    {
        private ObservableCollection<UnitInformation> _unitInformations;

        public SectionSetupVm()
            : base("Section Setup")
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

        public override void UpdateCommandExecute(SectionInformation entity)
        {
            if (DataRepository.IsEntityExists(x => x.SectionName.Equals(entity.SectionName, StringComparison.OrdinalIgnoreCase) && x.UnitInformations.Id == entity.UnitInformations.Id))
            {
                MessageBox.Show(string.Format(ErrorMessage[16], "Section Name"), SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                DataRepository.ClearChanges(entity);
                return;
            }
            base.UpdateCommandExecute(entity);
        }

        public override bool CommandCanExecute(SectionInformation entity)
        {
            try
            {
                return
                    !(String.IsNullOrEmpty(entity.SectionName) ||
                      String.IsNullOrEmpty(entity.UnitInformations.UnitName));
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
                                                    new ObservableCollection<SectionInformation>(
                                                        DataRepository.GetAll().OrderBy(x => x.SectionName));

                                                UnitInformations =
                                                    new ObservableCollection<UnitInformation>(DataRepository.GetUnits());
                                                IsBusy = false;
                                            });
        }

        #endregion
    }
}
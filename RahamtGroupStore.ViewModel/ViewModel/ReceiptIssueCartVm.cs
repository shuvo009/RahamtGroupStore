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
    public class ReceiptIssueCartVm : GenericViewModel<ReceiptAndIssueCardInformation>
    {
        private ObservableCollection<UnitInformation> _unitInformations;

        public ReceiptIssueCartVm()
            : base("Receipt & Issue Card Setup")
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

        public override void ResetCommandExecute(ReceiptAndIssueCardInformation entity)
        {
            entity.SectionInformation = null;
            entity.UnitInformation = null;
            base.ResetCommandExecute(entity);
        }

        public override void UpdateCommandExecute(ReceiptAndIssueCardInformation entity)
        {
            if (CheckItemExists(entity))
            {
                MessageBox.Show(string.Format(ErrorMessage[16], "Code Number or Description"), SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
                DataRepository.ClearChanges(entity);
                return;
            }
            base.UpdateCommandExecute(entity);
        }

        public override bool CommandCanExecute(ReceiptAndIssueCardInformation entity)
        {
            try
            {
                return !(String.IsNullOrEmpty(entity.CodeNo) ||
                         String.IsNullOrEmpty(entity.Description));
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Helper

        private bool CheckItemExists(ReceiptAndIssueCardInformation entity)
        {
            return (DataRepository.IsEntityExists(x => x.CodeNo.Equals(entity.CodeNo, StringComparison.OrdinalIgnoreCase) && x.UnitInformation.UnitName.Equals(entity.UnitInformation.UnitName, StringComparison.OrdinalIgnoreCase)
                                                       && x.SectionInformation.SectionName.Equals(entity.SectionInformation.SectionName, StringComparison.OrdinalIgnoreCase))
                    && entity.IsNew())
                   || (DataRepository.IsEntityExists(x => x.UnitInformation.UnitName.Equals(entity.UnitInformation.UnitName, StringComparison.OrdinalIgnoreCase)
                                                          && x.SectionInformation.SectionName.Equals(entity.SectionInformation.SectionName, StringComparison.OrdinalIgnoreCase) && x.Id != entity.Id && x.CodeNo.Equals(entity.CodeNo, StringComparison.InvariantCultureIgnoreCase))
                       && !entity.IsNew());
        }

        private async void InitialData()
        {
            IsBusy = true;
            await Task.Factory.StartNew(() =>
                                            {
                                                UnitInformations =
                                                         new ObservableCollection<UnitInformation>(DataRepository.GetUnits());

                                                ItemCollection =
                                                    new ObservableCollection<ReceiptAndIssueCardInformation>(DataRepository.GetAll().OrderBy(x => x.CodeNo));

                                                IsBusy = false;
                                            });
        }

        #endregion
    }
}
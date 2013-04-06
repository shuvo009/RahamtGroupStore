using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class ReceiptAndIssueCardListVm : SearchWithPrint<ReceiptAndIssueCardInformation>
    {
        private ObservableCollection<UnitInformation> _unitInformations;

        public ReceiptAndIssueCardListVm()
            : base("Receipt And Issue Card List")
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

        public override bool CommandCanExecute(ReceiptAndIssueCardInformation entity)
        {
            throw new NotImplementedException();
        }

        protected override void SearchCommandExecute(ReceiptAndIssueCardInformation entity)
        {
            try
            {
                ItemCollection.Clear();
                ItemCollection = entity.SectionInformation != null
                                     ? new ObservableCollection<ReceiptAndIssueCardInformation>(DataRepository.Search(x => x.UnitInformation.Id == entity.UnitInformation.Id && x.SectionInformation.Id == entity.SectionInformation.Id))
                                     : new ObservableCollection<ReceiptAndIssueCardInformation>(DataRepository.Search(x => x.UnitInformation.Id == entity.UnitInformation.Id));
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[15], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override bool SearchCommandCanExecute(ReceiptAndIssueCardInformation entity)
        {
            try
            {
                return entity.UnitInformation != null;
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
                        new ObservableCollection<ReceiptAndIssueCardInformation>(
                            DataRepository.GetAll().OrderBy(x => x.CodeNo));
                    UnitInformations = new ObservableCollection<UnitInformation>(DataRepository.GetUnits());
                    IsBusy = false;
                });
        }

        #endregion
    }
}
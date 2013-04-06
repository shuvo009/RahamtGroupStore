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
    public class ReceiveIssueCardHistoryVm : ReceiptIssue<ReceiptAndIssueCard>
    {
        private DateTime _firstDate;
        private ReceiptAndIssueCardInformation _receiptAndIssueCardInformation;

        public ReceiveIssueCardHistoryVm()
            : base("Receipt and Issue Card")
        {
            FirstDate = DateTime.Today;
            Messenger.Default.Register(this, new Action<ReceiptAndIssueCardInformation>(receiptIssueInfo =>
                                                                                            {
                                                                                                SelectedReceiptIssueCardInfo
                                                                                                    =
                                                                                                    DataRepository.GetReceiptIssueCardInfoById(receiptIssueInfo.Id);
                                                                                            }));
        }

        public ReceiptAndIssueCardInformation SelectedReceiptIssueCardInfo
        {
            get { return _receiptAndIssueCardInformation; }
            set
            {
                _receiptAndIssueCardInformation = value;
                OnPeroertyChange("SelectedReceiptIssueCardInfo");
            }
        }

        public DateTime FirstDate
        {
            get { return _firstDate; }
            set
            {
                _firstDate = value;
                OnPeroertyChange("FirstDate");
            }
        }

        public override bool CommandCanExecute(ReceiptAndIssueCard entity)
        {
            throw new NotImplementedException();
        }

        protected override async void SearchCommandExecute(ReceiptAndIssueCard entity)
        {
            try
            {
                IsBusy = true;
                await Task.Factory.StartNew(() =>
                                                {
                                                    ItemCollection =
                                                        new ObservableCollection<ReceiptAndIssueCard>(DataRepository.Search(x =>
                                                                                                                            x.EntryDate >=
                                                                                                                            FirstDate &&
                                                                                                                            x.EntryDate <=
                                                                                                                            SecondDate &&
                                                                                                                            x.ReceiptAndIssueCardInformation
                                                                                                                                .Id == SelectedReceiptIssueCardInfo
                                                                                                                                           .Id).OrderByDescending(x => x.EntryDate));
                                                    IsBusy = false;
                                                });
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[15], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override bool SearchCommandCanExecute(ReceiptAndIssueCard entity)
        {
            try
            {
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override void ResetCommandExecute(ReceiptAndIssueCard entity)
        {
            ItemCollection = null;
            SelectedReceiptIssueCardInfo = null;
            FirstDate = SecondDate = DateTime.Today;
        }
    }
}
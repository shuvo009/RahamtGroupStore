using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.Common;

namespace RahamtGroupStore.ViewModel.ViewModel
{
    public class ReceiveIssueTransactionVm : ReceiptIssue<ReceiptAndIssueCard>
    {
        private ReceiptAndIssueCardInformation _receiptAndIssueCard;

        public ReceiveIssueTransactionVm()
            : base("Receive And Issue Transaction")
        {
            Messenger.Default.Register(this, new Action<ReceiptAndIssueCardInformation>(receiptIssueInfo =>
                                                                                            {
                                                                                                if (receiptIssueInfo == null) return;
                                                                                                ReceiptAndIssueCard = DataRepository.GetReceiptIssueCardInfoById(receiptIssueInfo.Id);
                                                                                                try
                                                                                                {
                                                                                                    ItemCollection = new ObservableCollection<ReceiptAndIssueCard>
                                                                                                        (DataRepository.GetReceiptAndIssueCardsById(receiptIssueInfo.Id));
                                                                                                }
                                                                                                catch
                                                                                                {
                                                                                                }
                                                                                            }));
            NewCommand.Execute(null);
        }

        public virtual ReceiptAndIssueCardInformation ReceiptAndIssueCard
        {
            get { return _receiptAndIssueCard; }
            set
            {
                _receiptAndIssueCard = value;
                OnPeroertyChange("ReceiptAndIssueCard");
            }
        }

        public override void UpdateCommandExecute(ReceiptAndIssueCard entity)
        {
            int balance = (ReceiptAndIssueCard.BalanceQuantity + entity.Received) - entity.Issued;
            ReceiptAndIssueCard.BalanceQuantity = balance;
            entity.Balance = balance;
            entity.ReceiptAndIssueCardInformation = ReceiptAndIssueCard;
            base.UpdateCommandExecute(entity);
            NewCommand.Execute(null);
        }

        protected override void NewCommandExecute(ReceiptAndIssueCard entity)
        {
            if (ItemCollection != null)
                ItemCollection.Clear();

            ReceiptAndIssueCard = null;
            base.NewCommandExecute(entity);
        }

        public override bool CommandCanExecute(ReceiptAndIssueCard entity)
        {
            try
            {
                return !(String.IsNullOrEmpty(entity.MrrOrSrNo) ||
                         (entity.Issued < 0 || entity.Received < 0));
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override void SearchCommandExecute(ReceiptAndIssueCard entity)
        {
            throw new NotImplementedException();
        }

        protected override bool SearchCommandCanExecute(ReceiptAndIssueCard entity)
        {
            throw new NotImplementedException();
        }
    }
}
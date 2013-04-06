using RahamtGroupStore.Model.Interfaces;
using System;
using System.Windows;

namespace RahamtGroupStore.ViewModel.Common
{
    public abstract class ReceiptIssue<T> : SearchWithPrint<T>
        where T : class,IEntity, new()
    {
        #region Delegates

        public delegate void ReceiptIssueInfo();

        #endregion

        #region Event

        public event ReceiptIssueInfo GetReceiptIssueInfo;

        #endregion

        protected ReceiptIssue(string title) : base(title)
        {
            GetReceiptIssueCommand = new RelayCommand<T>(GetReceiptIssueExecute);
            CardListContext = "Card List";
        }

        public RelayCommand<T> GetReceiptIssueCommand { get; set; }

        public string CardListContext { get; set; }

        private void GetReceiptIssueExecute(T entity)
        {
            try
            {
                if (GetReceiptIssueInfo != null)
                {
                    GetReceiptIssueInfo();
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                MessageBox.Show(ErrorMessage[9], SoftwareName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
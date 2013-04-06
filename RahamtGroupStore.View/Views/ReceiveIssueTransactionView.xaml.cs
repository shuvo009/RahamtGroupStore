using RahamtGroupStore.ViewModel.ViewModel;
using System.Windows.Controls;
using RahamtGroupStore.View.Windows;

namespace RahamtGroupStore.View.Views
{
	/// <summary>
	/// Interaction logic for ReceiveIssueTransactionView.xaml
	/// </summary>
	public partial class ReceiveIssueTransactionView : UserControl
	{
		public ReceiveIssueTransactionView()
		{
			this.InitializeComponent();
		    var receiveIssueTransaction = new ReceiveIssueTransactionVm();
		    DataContext = receiveIssueTransaction;
            receiveIssueTransaction.GetReceiptIssueInfo += receiveIssueTransaction_GetReceiptIssueInfo;
		}

        void receiveIssueTransaction_GetReceiptIssueInfo()
        {
            new ReceiptIssueCartWindow().ShowDialog();
        }
	}
}
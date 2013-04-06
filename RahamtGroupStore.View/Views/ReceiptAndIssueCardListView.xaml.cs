using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.ViewModel;
using System.Windows.Controls;
using RahamtGroupStore.View.Windows;
using RahamtGroupStore.View.Reports;
namespace RahamtGroupStore.View.Views
{
	/// <summary>
	/// Interaction logic for ReceiptAndIssueCardListView.xaml
	/// </summary>
	public partial class ReceiptAndIssueCardListView : UserControl
	{
        #region Delegates

        public delegate void DoubleclickOnGridView();

        #endregion

		public ReceiptAndIssueCardListView()
		{
			this.InitializeComponent();
		    var receiptAndIssueList = new ReceiptAndIssueCardListVm();
		    DataContext = receiptAndIssueList;
            receiptAndIssueList.CloseWindow += ReceiptAndIssueListCloseWindow;
            receiptAndIssueList.StartingReport += receiptAndIssueList_StartingReport;
		}

        void receiptAndIssueList_StartingReport(System.Collections.Generic.IEnumerable<ReceiptAndIssueCardInformation> datalist)
        {
            var receiveIssueCardList = new ReceiptAndIssueCardListReport
                                           {
                                               ReceiptIssueSource = {DataSource = datalist}
                                           };
            new ViewingRepots().LoadReport(receiveIssueCardList);
        }

        public event DoubleclickOnGridView OnDoubleclickOnGridView;

        void ReceiptAndIssueListCloseWindow()
        {
            if (OnDoubleclickOnGridView != null)
            {
                OnDoubleclickOnGridView();
            }
        }
	}
}
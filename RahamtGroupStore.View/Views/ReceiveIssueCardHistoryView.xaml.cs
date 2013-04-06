using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.ViewModel;
using System.Collections.Generic;
using System.Windows.Controls;
using RahamtGroupStore.View.Windows;
using RahamtGroupStore.View.Reports;

namespace RahamtGroupStore.View.Views
{
	/// <summary>
	/// Interaction logic for ReceiveIssueCardHistoryView.xaml
	/// </summary>
	public partial class ReceiveIssueCardHistoryView : UserControl
	{
		public ReceiveIssueCardHistoryView()
		{
			this.InitializeComponent();
		    var receiveIssueHistory = new ReceiveIssueCardHistoryVm();
		    DataContext = receiveIssueHistory;
            receiveIssueHistory.StartingReport += receiveIssueHistory_StartingReport;
            receiveIssueHistory.GetReceiptIssueInfo += receiveIssueHistory_GetReceiptIssueInfo;
		}

        void receiveIssueHistory_GetReceiptIssueInfo()
        {
            new ReceiptIssueCartWindow().ShowDialog();
        }

        void receiveIssueHistory_StartingReport(IEnumerable<ReceiptAndIssueCard> datalist)
        {
            var receiveIssueReport = new ReceiveIssueCardHistoryReport
                                         {
                                             ReceiveIssueHistorySource = {DataSource = datalist}
                                         };
            new ViewingRepots().LoadReport(receiveIssueReport);
        }
	}
}
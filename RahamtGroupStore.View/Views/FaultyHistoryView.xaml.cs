using System.Collections.Generic;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.ViewModel;
using System.Windows.Controls;
using RahamtGroupStore.View.Reports;

namespace RahamtGroupStore.View.Views
{
	/// <summary>
	/// Interaction logic for FaultyHistoryView.xaml
	/// </summary>
	public partial class FaultyHistoryView : UserControl
	{
		public FaultyHistoryView()
		{
			this.InitializeComponent();
		    var faultyHistory = new FaultyHistoryVm();
		    DataContext = faultyHistory;
            faultyHistory.StartingReport += faultyHistory_StartingReport;
        }

        void faultyHistory_StartingReport(IEnumerable<FaultSpareHistory> datalist)
        {
            var faultyHistoryreport = new FaultHistoryReport
                                          {
                                              FaultHistoryDataSource = {DataSource = datalist}
                                          };
            new ViewingRepots().LoadReport(faultyHistoryreport);
        }
	}
}
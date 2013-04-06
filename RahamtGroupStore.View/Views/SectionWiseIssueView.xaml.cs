using System.Collections.Generic;
using System.Windows.Controls;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.ViewModel;
using RahamtGroupStore.View.Reports;
using RahamtGroupStore.View.Windows;
namespace RahamtGroupStore.View.Views
{
	/// <summary>
	/// Interaction logic for SectionWiseIssueView.xaml
	/// </summary>
	public partial class SectionWiseIssueView : UserControl
	{
		public SectionWiseIssueView()
		{
			this.InitializeComponent();
		    var sectionWiseIssue = new SectionWiseIssueVm();
		    DataContext = sectionWiseIssue;
            sectionWiseIssue.StartingReport += sectionWiseIssue_StartingReport;
		}

        void sectionWiseIssue_StartingReport(IEnumerable<IssueSpareParts> datalist)
        {
            var sectionWiseIssueReport = new SectionWiseIssueReport
                                             {
                                                 sectionWiseIssueDataSource = {DataSource = datalist}
                                             };
            new ViewingRepots().LoadReport(sectionWiseIssueReport);
        }
	}
}
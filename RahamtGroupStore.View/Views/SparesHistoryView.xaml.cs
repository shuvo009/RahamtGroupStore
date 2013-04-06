using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.ViewModel;
using System.Collections.Generic;
using System.Windows.Controls;
using RahamtGroupStore.View.Windows;
using RahamtGroupStore.View.Reports;

namespace RahamtGroupStore.View.Views
{
	/// <summary>
	/// Interaction logic for SparesHistoryView.xaml
	/// </summary>
	public partial class SparesHistoryView : UserControl
	{
		public SparesHistoryView()
		{
			this.InitializeComponent();
		    var sparesHistoryVm = new SparesHistoryVm();
		    DataContext = sparesHistoryVm;
            sparesHistoryVm.GetMachineInfo += machineLedger_GetMachineInfo;
            sparesHistoryVm.StartingReport += machineLedger_StartingReport;
		}

        void machineLedger_StartingReport(IEnumerable<MachineLedger> datalist)
        {
            var machineLedger = new SparesHistoryReport
                                    {
                                        SparesHistorySource = {DataSource = datalist}
                                    };
            new ViewingRepots().LoadReport(machineLedger);
        }

        void machineLedger_GetMachineInfo()
        {
            new MachinListWindow().ShowDialog();
        }
	}
}
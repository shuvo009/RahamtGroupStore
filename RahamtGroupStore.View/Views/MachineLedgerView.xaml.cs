using System.Collections.Generic;
using RahamtGroupStore.Model;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.View.Reports;
using RahamtGroupStore.View.Windows;
using RahamtGroupStore.ViewModel.ViewModel;
using System.Windows.Controls;

namespace RahamtGroupStore.View.Views
{
	/// <summary>
	/// Interaction logic for MachineLedgerView.xaml
	/// </summary>
	public partial class MachineLedgerView : UserControl
	{
		public MachineLedgerView()
		{
			this.InitializeComponent();
		    var machineLedger = new MachineLedgerVm();
		    DataContext = machineLedger;
            machineLedger.StartingReport += machineLedger_StartingPrint;
            machineLedger.GetMachineInfo += machineLedger_GetMachineInfo;
		}

        void machineLedger_GetMachineInfo()
        {
            new MachinListWindow().ShowDialog();
        }

        private void machineLedger_StartingPrint(IEnumerable<IssueSpareParts> datalist)
        {
            var machineLedger = new MachineLedgerReport
                                    {
                                        MachineLegerDataSource = {DataSource = datalist}
                                    };
            new ViewingRepots().LoadReport(machineLedger);
        }
	}
}
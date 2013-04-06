using System.Collections.Generic;
using System.Windows.Controls;
using RahamtGroupStore.Model;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.View.Reports;
using RahamtGroupStore.ViewModel.ViewModel;

namespace RahamtGroupStore.View.Views
{
    /// <summary>
    /// Interaction logic for MachineListView.xaml
    /// </summary>
    public partial class MachineListView : UserControl
    {
        #region Delegates

        public delegate void DoubleclickOnGridView();

        #endregion

        public MachineListView()
        {
            InitializeComponent();
            var machineListVm = new MachineListVm();
            DataContext = machineListVm;
            machineListVm.CloseWindow += MachineListVmCloseWindow;
            machineListVm.StartingReport += machineListVm_StartingReport;
        }

        private void machineListVm_StartingReport(IEnumerable<MachineInformation> datalist)
        {
            var machinListReport = new MachineListReport
                                       {
                                           machineDataSource = {DataSource = datalist}
                                       };
            new ViewingRepots().LoadReport(machinListReport);
        }

        public event DoubleclickOnGridView OnDoubleclickOnGridView;

        private void MachineListVmCloseWindow()
        {
            if (OnDoubleclickOnGridView != null)
            {
                OnDoubleclickOnGridView();
            }
        }
    }
}
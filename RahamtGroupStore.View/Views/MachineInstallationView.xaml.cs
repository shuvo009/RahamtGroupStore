using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.View.Reports;
using RahamtGroupStore.ViewModel.ViewModel;
using System.Windows.Controls;

namespace RahamtGroupStore.View.Views
{
    /// <summary>
    /// Interaction logic for MachineInstallationView.xaml
    /// </summary>
    public partial class MachineInstallationView : UserControl
    {
        public MachineInstallationView()
        {
            InitializeComponent();
            var machineInfo = new MachineInstallationVm();
            DataContext = machineInfo;
            machineInfo.OnSinglePrint += machineInfo_OnSinglePrint;
        }

        void machineInfo_OnSinglePrint(MachineInformation entity)
        {
            var faultyReport = new SingleMachinfoReport{ MachinInfoDataSource = { DataSource = entity } };
            new ViewingRepots().LoadReport(faultyReport);
        }
    }
}
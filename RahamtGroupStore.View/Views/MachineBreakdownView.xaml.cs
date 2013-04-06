using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using RahamtGroupStore.View.Windows;
using RahamtGroupStore.ViewModel.ViewModel;

namespace RahamtGroupStore.View.Views
{
    /// <summary>
    /// Interaction logic for MachineBreakdownView.xaml
    /// </summary>
    public partial class MachineBreakdownView : UserControl
    {
        private readonly MachineBreakdownVm _machineBreakdownVm = new MachineBreakdownVm();

        public MachineBreakdownView()
        {
            InitializeComponent();

            DataContext = _machineBreakdownVm;
            _machineBreakdownVm.GetMachineInfo += GetMachineInfo_MachineBRV;
            _machineBreakdownVm.GetSpareInfo += GetSpareInfoMachineBrv;
        }

        private void GetSpareInfoMachineBrv()
        {
            var spareList = new SpareListWindow();
            Messenger.Default.Send(_machineBreakdownVm.SelectedItem.MachineInformation.Id);
            spareList.ShowDialog();
        }

        private void GetMachineInfo_MachineBRV()
        {
            new MachinListWindow().ShowDialog();
        }
    }
}
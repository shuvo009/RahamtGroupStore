using System.Windows.Controls;
using RahamtGroupStore.View.Windows;
using RahamtGroupStore.ViewModel.ViewModel;

namespace RahamtGroupStore.View.Views
{
    /// <summary>
    /// Interaction logic for SpareSetupView.xaml
    /// </summary>
    public partial class SpareSetupView : UserControl
    {
        public SpareSetupView()
        {
            InitializeComponent();
            var spareSetupVm = new SpareSetupVm();
            DataContext = spareSetupVm;
            spareSetupVm.GetMachineInfo += SpareSetupVmMachinInfoGet;
        }

        private void SpareSetupVmMachinInfoGet()
        {
            new MachinListWindow().ShowDialog();
        }
    }
}
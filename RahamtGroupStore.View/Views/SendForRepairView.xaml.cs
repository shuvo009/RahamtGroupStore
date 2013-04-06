using RahamtGroupStore.ViewModel.ViewModel;
using System.Windows.Controls;
using RahamtGroupStore.View.Windows;

namespace RahamtGroupStore.View.Views
{
	/// <summary>
	/// Interaction logic for SendForRepairView.xaml
	/// </summary>
	public partial class SendForRepairView : UserControl
	{
		public SendForRepairView()
		{
			this.InitializeComponent();
		    var sendForRepair = new SendForRepairVm();
		    DataContext = sendForRepair;
            sendForRepair.GetMachineInfo += sendForRepair_GetMachineInfo; // This use for Get Repair Company Information
            sendForRepair.GetSpareInfo += sendForRepair_GetSpareInfo; // This use for Get Faulty Informations
		}

        void sendForRepair_GetSpareInfo()
        {
            new FaultyListWindow().ShowDialog();
        }

        void sendForRepair_GetMachineInfo()
        {
            new RepairCompanyListWindow().ShowDialog();
        }
	}
}
using System.Windows.Controls;
using RahamtGroupStore.View.Windows;
using RahamtGroupStore.ViewModel.ViewModel;

namespace RahamtGroupStore.View.Views
{
    /// <summary>
    /// Interaction logic for IssueSpareView.xaml
    /// </summary>
    public partial class IssueSpareView : UserControl
    {
        public IssueSpareView()
        {
            InitializeComponent();
            var issueSpares = new IssuePartsVm();
            DataContext = issueSpares;
            issueSpares.GetMachineInfo += issueSpares_GetMachineInfo;
            issueSpares.GetSpareInfo += issueSpares_GetSpareInfo;
        }

        private void issueSpares_GetSpareInfo()
        {
            new SpareListWindow().ShowDialog();
        }

        private void issueSpares_GetMachineInfo()
        {
            new MachinListWindow().ShowDialog();
        }
    }
}
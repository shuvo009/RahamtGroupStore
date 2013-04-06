using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace RahamtGroupStore.View.Windows
{
    /// <summary>
    /// Interaction logic for RepairCompanyListWindow.xaml
    /// </summary>
    public partial class RepairCompanyListWindow : Window
    {
        public RepairCompanyListWindow()
        {
            InitializeComponent();

            repairCompanyList.OnDoubleclickOnGridView += repairCompanyList_OnDoubleclickOnGridView;
            Messenger.Default.Send(Visibility.Collapsed);
        }

        private void repairCompanyList_OnDoubleclickOnGridView()
        {
            Close();
        }
    }
}
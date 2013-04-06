using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace RahamtGroupStore.View.Windows
{
    /// <summary>
    /// Interaction logic for MachinListWindow.xaml
    /// </summary>
    public partial class MachinListWindow : Window
    {
        public MachinListWindow()
        {
            InitializeComponent();
            machineList.OnDoubleclickOnGridView += machineList_OnDoubleclickOnGridView;
            Messenger.Default.Send(Visibility.Collapsed);
        }

        private void machineList_OnDoubleclickOnGridView()
        {
            Close();
        }
    }
}
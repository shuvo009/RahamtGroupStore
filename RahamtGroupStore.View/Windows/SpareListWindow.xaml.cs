using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace RahamtGroupStore.View.Windows
{
    /// <summary>
    /// Interaction logic for SpareListWindow.xaml
    /// </summary>
    public partial class SpareListWindow : Window
    {
        public SpareListWindow()
        {
            InitializeComponent();
            spareList.OnDoubleclickOnGridView += spareList_OnDoubleclickOnGridView;
            Messenger.Default.Send(Visibility.Collapsed);
        }

        private void spareList_OnDoubleclickOnGridView()
        {
            Close();
        }

    }
}
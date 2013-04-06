using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace RahamtGroupStore.View.Windows
{
    /// <summary>
    /// Interaction logic for SupplierListWindow.xaml
    /// </summary>
    public partial class SupplierListWindow : Window
    {
        public SupplierListWindow()
        {
            InitializeComponent();
            supplierList.OnDoubleclickOnGridView += supplierList_OnDoubleclickOnGridView;
            Messenger.Default.Send(Visibility.Collapsed);
        }

        private void supplierList_OnDoubleclickOnGridView()
        {
            Close();
        }
    }
}
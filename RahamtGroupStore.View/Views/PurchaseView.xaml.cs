using System.Windows.Controls;
using RahamtGroupStore.View.Windows;
using RahamtGroupStore.ViewModel.ViewModel;

namespace RahamtGroupStore.View.Views
{
    /// <summary>
    /// Interaction logic for PurchaseView.xaml
    /// </summary>
    public partial class PurchaseView : UserControl
    {
        public PurchaseView()
        {
            InitializeComponent();
            var purchase = new PurchaseVm();
            DataContext = purchase;
            purchase.GetSupplierInfo += purchase_GetSupplierInfo;
            purchase.GetSpareInfo += purchase_GetSpareInfo;
        }

        private void purchase_GetSpareInfo()
        {
            new SpareListWindow().ShowDialog();
        }

        private void purchase_GetSupplierInfo()
        {
            new SupplierListWindow().ShowDialog();
        }
    }
}
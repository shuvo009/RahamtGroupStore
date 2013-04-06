using System.Windows.Controls;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.ViewModel;
using RahamtGroupStore.View.Windows;
using RahamtGroupStore.View.Reports;
namespace RahamtGroupStore.View.Views
{
    /// <summary>
    /// Interaction logic for SupplierListView.xaml
    /// </summary>
    public partial class SupplierListView : UserControl
    {
        #region Delegates

        public delegate void DoubleclickOnGridView();

        #endregion

        public SupplierListView()
        {
            InitializeComponent();
            var supplierListVm = new SupplierListVm();
            DataContext = supplierListVm;
            supplierListVm.CloseWindow += SupplierListVmCloseWindow;
            supplierListVm.StartingReport += supplierListVm_StartingReport;
        }

        void supplierListVm_StartingReport(System.Collections.Generic.IEnumerable<SupplierInformation> datalist)
        {
            var supplierList = new SupplierListReport
                                   {
                                       SupplierListSource = {DataSource = datalist}
                                   };
            new ViewingRepots().LoadReport(supplierList);
        }

        public event DoubleclickOnGridView OnDoubleclickOnGridView;

        private void SupplierListVmCloseWindow()
        {
            if (OnDoubleclickOnGridView != null)
            {
                OnDoubleclickOnGridView();
            }
        }
    }
}
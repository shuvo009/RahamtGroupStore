using System.Windows.Controls;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.ViewModel;
using RahamtGroupStore.Model;
using System.Collections.Generic;
using RahamtGroupStore.View.Reports;
namespace RahamtGroupStore.View.Views
{
    /// <summary>
    /// Interaction logic for FaultyListView.xaml
    /// </summary>
    public partial class FaultyListView : UserControl
    {
        #region Delegates

        public delegate void DoubleclickOnGridView();

        #endregion

        public FaultyListView()
        {
            InitializeComponent();
            var faltyListvm = new FaultyListVm();
            DataContext = faltyListvm;
            faltyListvm.CloseWindow += FaltyListvmCloseWindow;
            faltyListvm.StartingReport += faltyListvm_StartingReport;
        }

        void faltyListvm_StartingReport(IEnumerable<MachineBreakdownInformation> datalist)
        {
            var faultyReport = new FaultyListReport {FaultyDataSource = {DataSource = datalist}};
            new ViewingRepots().LoadReport(faultyReport);
        }

        public event DoubleclickOnGridView OnDoubleclickOnGridView;

        private void FaltyListvmCloseWindow()
        {
            if (OnDoubleclickOnGridView != null)
            {
                OnDoubleclickOnGridView();
            }
        }
    }
}
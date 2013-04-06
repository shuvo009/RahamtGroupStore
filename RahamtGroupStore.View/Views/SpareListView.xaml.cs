using System.Windows.Controls;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.ViewModel;
using RahamtGroupStore.View.Windows;
using RahamtGroupStore.View.Reports;
namespace RahamtGroupStore.View.Views
{
    /// <summary>
    /// Interaction logic for SpareListView.xaml
    /// </summary>
    public partial class SpareListView : UserControl
    {
        #region Delegates

        public delegate void DoubleclickOnGridView();

        #endregion

        public SpareListView()
        {
            InitializeComponent();
            var spareListvm = new SparesListVm();
            DataContext = spareListvm;
            spareListvm.CloseWindow += SpareListvmCloseWindow;
            spareListvm.StartingReport += spareListvm_StartingReport;
        }

        void spareListvm_StartingReport(System.Collections.Generic.IEnumerable<SparesInformation> datalist)
        {
            var spareList = new SpareListReport
                                {
                                    SpareInfoSource = {DataSource = datalist}
                                };
        new ViewingRepots().LoadReport(spareList);
        }

        public event DoubleclickOnGridView OnDoubleclickOnGridView;

        private void SpareListvmCloseWindow()
        {
            if (OnDoubleclickOnGridView != null)
            {
                OnDoubleclickOnGridView();
            }
        }
    }
}
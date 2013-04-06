using System.Windows.Controls;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.ViewModel;
using RahamtGroupStore.View.Windows;
using RahamtGroupStore.View.Reports;
namespace RahamtGroupStore.View.Views
{
    /// <summary>
    /// Interaction logic for FaultyListView.xaml
    /// </summary>
    public partial class RepairCompnayListView : UserControl
    {
        #region Delegates

        public delegate void DoubleclickOnGridView();

        #endregion

        public RepairCompnayListView()
        {
            InitializeComponent();
            var repairCompnayList = new RepairCompanyListVm();
            DataContext = repairCompnayList;
            repairCompnayList.CloseWindow += RepairCompnayListCloseWindow;
            repairCompnayList.StartingReport += repairCompnayList_StartingReport;
        }

        void repairCompnayList_StartingReport(System.Collections.Generic.IEnumerable<RepairCompaneyInformation> datalist)
        {
            var repairCompanyList = new RepairCompnayListReport
                                        {
                                            RepairCompanySource = {DataSource = datalist}
                                        };
            new ViewingRepots().LoadReport(repairCompanyList);
        }

        public event DoubleclickOnGridView OnDoubleclickOnGridView;

        private void RepairCompnayListCloseWindow()
        {
            if (OnDoubleclickOnGridView != null)
            {
                OnDoubleclickOnGridView();
            }
        }
    }
}
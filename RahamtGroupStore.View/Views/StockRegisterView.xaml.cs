using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.ViewModel.ViewModel;
using System.Collections.Generic;
using System.Windows.Controls;
using RahamtGroupStore.View.Reports;

namespace RahamtGroupStore.View.Views
{
	/// <summary>
	/// Interaction logic for StockRegisterView.xaml
	/// </summary>
	public partial class StockRegisterView : UserControl
	{
		public StockRegisterView()
		{
			this.InitializeComponent();
		    var stockRegister = new StockRegisterVm();
		    DataContext = stockRegister;
            stockRegister.StartingReport += stockRegister_StartingReport;
		}

        void stockRegister_StartingReport(IEnumerable<StockRegister> datalist)
        {
            var stockRegister = new StockRegisterReport
                                    {
                                        StockRegisterSource = {DataSource = datalist}
                                    };
            new ViewingRepots().LoadReport(stockRegister);
        }
	}
}
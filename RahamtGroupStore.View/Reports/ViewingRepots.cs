using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Reporting;
using RahamtGroupStore.ViewModel.Methods;
using RahamtGroupStore.View.Windows;
namespace RahamtGroupStore.View.Reports
{
   public class ViewingRepots
    {
       public void LoadReport(Report report)
       {
           var mainReport = new MainReport
                                {
                                    CompanyInformationDS = {DataSource = new MiraculousMethods().GetCompanyInformation()},
                                    ReportHoster = {ReportSource = report}
                                };
           var instanceReportSource = new InstanceReportSource {ReportDocument = mainReport};
           var reportViewer = new ReportViewer { ReportHost = { ReportSource = instanceReportSource } };
           reportViewer.ShowDialog();
       }
    }
}

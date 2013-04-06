using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using RahamtGroupStore.View.Views;
namespace RahamtGroupStore.View.Commands
{
   public class RepairCompanyListCommand :ICommandFactory,ICommand
    {
       public string CommandName { get { return "RepairCompanyList"; }
       }
       public ContentPresenter ContentPre { get; set; }
       public ICommand MakeCommand(ContentPresenter contentPresenter)
       {
           return new RepairCompanyListCommand
                      {
                          ContentPre = contentPresenter
                      };
       }

       public void Execute()
       {
           ContentPre.Content = new RepairCompnayListView();
       }
    }
}

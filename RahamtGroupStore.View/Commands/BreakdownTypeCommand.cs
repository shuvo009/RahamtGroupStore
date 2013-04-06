using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using RahamtGroupStore.View.Views;
namespace RahamtGroupStore.View.Commands
{
    public class BreakdownTypeCommand :ICommand,ICommandFactory
    {

        public void Execute()
        {
            ContentPre.Content = new BreakdownType();
        }

        public string CommandName
        {
            get { return "BreakdownTypeSetup"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
           return new BreakdownTypeCommand
                      {
                          ContentPre = contentPresenter
                      };
        }
    }
}

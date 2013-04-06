using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    class MachineLegerCommand : ICommandFactory, ICommand
    {
        public string CommandName { get { return "MachineLedger"; }
        }
        public ContentPresenter ContentPre { get; set; }
        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new MachineLegerCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        public void Execute()
        {
            ContentPre.Content = new MachineLedgerView();
        }
    }
}

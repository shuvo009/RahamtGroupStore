using RahamtGroupStore.View.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace RahamtGroupStore.View.Commands
{
    class FaultHistoryCommand : ICommand, ICommandFactory
    {
        public void Execute()
        {
            ContentPre.Content = new FaultyHistoryView();   
        }

        public string CommandName
        {
            get { return "FaultyHistory"; }
        }
        public ContentPresenter ContentPre { get; set; }
        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new FaultHistoryCommand
                       {
                           ContentPre = contentPresenter
                       };
        }
    }
}

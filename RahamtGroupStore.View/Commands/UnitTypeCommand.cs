using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class UnitTypeCommand : ICommand, ICommandFactory
    {
        public void Execute()
        {
            ContentPre.Content = new UnitTypeSetupView();
        }

        public string CommandName
        {
            get { return "UnitType"; }
        }
        public ContentPresenter ContentPre { get; set; }
        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new UnitTypeCommand
                       {
                           ContentPre = contentPresenter
                       };
        }
    }
}

using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class MachineBreakdownCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new MachineBreakdownView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "MachineBreakdown"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new MachineBreakdownCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
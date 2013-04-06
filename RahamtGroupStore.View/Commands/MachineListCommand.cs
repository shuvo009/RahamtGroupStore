using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class MachineListCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new MachineListView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "MachineList"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new MachineListCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
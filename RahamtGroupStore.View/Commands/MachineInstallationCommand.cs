using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class MachineInstallationCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new MachineInstallationView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "MachineInstallation"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new MachineInstallationCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
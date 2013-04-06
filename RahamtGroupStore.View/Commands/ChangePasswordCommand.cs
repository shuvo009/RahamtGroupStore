using System.Windows.Controls;

namespace RahamtGroupStore.View.Commands
{
    public class ChangePasswordCommand : ICommand, ICommandFactory
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new ChanagePasswordView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "ChangePassword"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new ChangePasswordCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
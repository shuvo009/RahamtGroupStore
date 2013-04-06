using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RahamtGroupStore.View.Windows;

namespace RahamtGroupStore.View.Commands
{
    public class LoginCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            new LoginWindow().Show();
            Application.Current.Windows.Cast<Window>().Single(x => x.Name.Equals("HostWindow")).Close();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "Login"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new LoginCommand {ContentPre = contentPresenter};
        }

        #endregion
    }
}
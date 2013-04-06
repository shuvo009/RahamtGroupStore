using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class SparesSetupCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new SpareSetupView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "SparesSetup"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new SparesSetupCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
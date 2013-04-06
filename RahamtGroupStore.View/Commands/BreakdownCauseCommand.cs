using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class BreakdownCauseCommand : ICommand, ICommandFactory
    {
        public ContentPresenter ContentPre { get; set; }

        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new BreakdownCause();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "BreakdownCaseSetup"; }
        }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new BreakdownCauseCommand {ContentPre = contentPresenter};
        }

        #endregion
    }
}
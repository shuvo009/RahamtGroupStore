using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class CardHistoryCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new ReceiveIssueCardHistoryView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "CardHistory"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new CardHistoryCommand {ContentPre = contentPresenter};
        }

        #endregion
    }
}
using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class CardTransactionCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new ReceiveIssueTransactionView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "CardTransaction"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new CardTransactionCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
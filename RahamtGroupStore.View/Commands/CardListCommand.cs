using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class CardListCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new ReceiptAndIssueCardListView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "CardList"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new CardListCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
using System.Windows.Controls;

namespace RahamtGroupStore.View.Commands
{
    public class CardSetupCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new ReceiptIssueCartView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "CardSetup"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new CardSetupCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
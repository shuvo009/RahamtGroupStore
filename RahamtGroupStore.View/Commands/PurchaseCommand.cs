using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class PurchaseCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new PurchaseView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "Purchase"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new PurchaseCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
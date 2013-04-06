using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class SupplierListCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new SupplierListView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "SupplierList"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new SupplierListCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
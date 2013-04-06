using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class SupplierCommand : ICommand, ICommandFactory
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new SupplierSetupView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "SupplierSetup"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new SupplierCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
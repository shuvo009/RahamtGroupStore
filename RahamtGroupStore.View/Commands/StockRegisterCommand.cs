using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class StockRegisterCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new StockRegisterView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "StockRegister"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new StockRegisterCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
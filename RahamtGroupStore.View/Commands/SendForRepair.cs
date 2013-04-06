using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class SendForRepair : ICommand, ICommandFactory
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new SendForRepairView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "SendForRepair"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new SendForRepair
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
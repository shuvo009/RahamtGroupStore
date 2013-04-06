using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class SparesHistoryCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new SparesHistoryView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "SparesHistory"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new SparesHistoryCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
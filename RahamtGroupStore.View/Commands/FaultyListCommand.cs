using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class FaultyListCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new FaultyListView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "FaultyList"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new FaultyListCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class SpareListCommand : ICommand, ICommandFactory
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new SpareListView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "SpareList"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new SpareListCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
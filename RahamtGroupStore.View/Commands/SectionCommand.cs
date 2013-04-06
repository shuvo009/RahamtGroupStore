using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class SectionCommand : ICommand, ICommandFactory
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new SectionSetupView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "SectionSetup"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new SectionCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
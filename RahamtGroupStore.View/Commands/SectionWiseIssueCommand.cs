using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class SectionWiseIssueCommand : ICommand, ICommandFactory
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new SectionWiseIssueView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "SectionWiseIssue"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new SectionWiseIssueCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
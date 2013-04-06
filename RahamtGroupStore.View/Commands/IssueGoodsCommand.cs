using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class IssueGoodsCommand : ICommand, ICommandFactory
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new IssueSpareView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "IssueGoods"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new IssueGoodsCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
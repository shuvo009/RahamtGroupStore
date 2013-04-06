using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class OrdinaryTypeCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new OrdinaryTypeView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "OrdinaryTypeSetup"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new OrdinaryTypeCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
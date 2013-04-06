using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class UnitCommand : ICommand, ICommandFactory
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new UnitInformationView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "UnitSetup"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new UnitCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
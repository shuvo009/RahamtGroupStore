using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class RepairComanyCommand : ICommand, ICommandFactory
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new RepairCompanyView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "RepairCompanySetup"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new RepairComanyCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
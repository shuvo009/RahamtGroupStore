using System.Windows.Controls;
using RahamtGroupStore.View.Views;

namespace RahamtGroupStore.View.Commands
{
    public class BackupRestoreCommand : ICommand, ICommandFactory
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new DatabaseBackupRestoreView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "BackupRestore"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new BackupRestoreCommand
                       {
                           ContentPre = contentPresenter
                       };
        }

        #endregion
    }
}
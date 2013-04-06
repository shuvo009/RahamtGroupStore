using System.Windows.Controls;

namespace RahamtGroupStore.View.Commands
{
    public class SpareReceiveCommand : ICommandFactory, ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            ContentPre.Content = new SpareReceiveView();
        }

        #endregion

        #region ICommandFactory Members

        public string CommandName
        {
            get { return "SpareReceive"; }
        }

        public ContentPresenter ContentPre { get; set; }

        public ICommand MakeCommand(ContentPresenter contentPresenter)
        {
            return new SpareReceiveCommand { ContentPre = contentPresenter };
        }

        #endregion
    }
}

using System.Windows.Controls;
namespace RahamtGroupStore.View.Commands
{
    public interface ICommandFactory
    {
        string CommandName { get; }
        ContentPresenter ContentPre { get; set; }

        ICommand MakeCommand(ContentPresenter contentPresenter);
    }
}
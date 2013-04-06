using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
namespace RahamtGroupStore.View.Commands
{
    public class CommandParser
    {
        private readonly IEnumerable<ICommandFactory> _availableCommands;

        public CommandParser(IEnumerable<ICommandFactory> availableCommands)
        {
            _availableCommands = availableCommands;
        }

        internal  ICommand ParseCommand(string requestedCommand, ContentPresenter contentPresenter)
        {
            var command = FindRequestedCommand(requestedCommand);
            if(command ==null)
                return new NotFoundCommand{Name = requestedCommand};
            return command.MakeCommand(contentPresenter);
        }

        ICommandFactory FindRequestedCommand(string commandName)
        {
            return _availableCommands.FirstOrDefault(x => x.CommandName.Equals(commandName));
        }
    }
}

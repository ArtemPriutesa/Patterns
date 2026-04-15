using System.Collections.Generic;
using Patterns.Behavioral.Command;

namespace Patterns.Behavioral.Iterator
{
    public class CommandHistory
    {
        private readonly List<ICommand> _commands = new();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public int GetCommandCount() => _commands.Count;

        public ICommandIterator CreateIterator()
        {
            return new CommandHistoryIterator(_commands);
        }

        public ICommandIterator CreateReverseIterator()
        {
            var reversedCommands = new List<ICommand>(_commands);
            reversedCommands.Reverse();
            return new CommandHistoryIterator(reversedCommands);
        }
    }
}

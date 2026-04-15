using System;
using System.Collections.Generic;
using Patterns.Behavioral.Command;

namespace Patterns.Behavioral.Iterator
{
    public class CommandHistoryIterator : ICommandIterator
    {
        private readonly List<ICommand> _commands;
        private int _currentIndex = 0;

        public CommandHistoryIterator(List<ICommand> commands)
        {
            _commands = new List<ICommand>(commands);
            _currentIndex = 0;
        }

        public bool HasNext()
        {
            return _currentIndex < _commands.Count;
        }

        public ICommand Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("Немає наступної команди в історії");
            }
            return _commands[_currentIndex++];
        }

        public bool HasPrevious()
        {
            return _currentIndex > 0;
        }

        public ICommand Previous()
        {
            if (!HasPrevious())
            {
                throw new InvalidOperationException("Немає попередньої команди в історії");
            }
            return _commands[--_currentIndex];
        }

        public void Reset()
        {
            _currentIndex = 0;
        }
    }
}

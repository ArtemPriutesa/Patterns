using System;
using System.Collections.Generic;

namespace Patterns.Behavioral.Command
{
    public class CommandInvoker
    {
        private readonly Stack<ICommand> _executedCommands = new();
        private readonly Stack<ICommand> _undoneCommands = new();

        public void ExecuteCommand(ICommand command)
        {
            Console.WriteLine($"Виконання команди: {command.GetDescription()}");
            
            command.Execute();
            
            _executedCommands.Push(command);
            _undoneCommands.Clear();
        }

        public void Undo()
        {
            if (_executedCommands.Count == 0)
            {
                Console.WriteLine("Нічого скасовувати");
                return;
            }

            ICommand command = _executedCommands.Pop();
            
            Console.WriteLine($" Скасування команди: {command.GetDescription()}");
            
            command.Undo();
            _undoneCommands.Push(command);
        }

        public void Redo()
        {
            if (_undoneCommands.Count == 0)
            {
                Console.WriteLine("Нічого повторювати");
                return;
            }

            ICommand command = _undoneCommands.Pop();
            
            Console.WriteLine($"Повторення команди: {command.GetDescription()}");
            
            command.Execute();
            _executedCommands.Push(command);
        }

        public void DisplayHistory()
        {
            Console.WriteLine("\nІсторія виконаних команд:");
            if (_executedCommands.Count == 0)
            {
                Console.WriteLine("  (пусто)");
                return;
            }

            var commands = new List<ICommand>(_executedCommands);
            for (int i = commands.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"  {i + 1}. {commands[i].GetDescription()}");
            }
        }

        public void DisplayUndoHistory()
        {
            Console.WriteLine("\nДоступні для повторення команди (Redo):");
            if (_undoneCommands.Count == 0)
            {
                Console.WriteLine("  (пусто)");
                return;
            }

            var commands = new List<ICommand>(_undoneCommands);
            for (int i = commands.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"  {i + 1}. {commands[i].GetDescription()}");
            }
        }
    }
}

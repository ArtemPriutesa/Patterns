using System;
using Patterns.Model;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Command
{
    /// <summary>
    /// Команда для оновлення CPU комп'ютера (upgrade)
    /// </summary>
    public class UpgradeCpuCommand : ICommand
    {
        private readonly Order _order;
        private readonly ICPU _newCpu;
        private readonly ICPU _oldCpu;

        public UpgradeCpuCommand(Order order, ICPU newCpu)
        {
            _order = order;
            _newCpu = newCpu;
            _oldCpu = order.Computer.CPU!;
        }

        public void Execute()
        {
            Console.WriteLine($"  Оновлення CPU: {_oldCpu.GetCPU()} → {_newCpu.GetCPU()}");
            _order.Computer.CPU = _newCpu;
        }

        public void Undo()
        {
            Console.WriteLine($"  Скасування оновлення: {_newCpu.GetCPU()} → {_oldCpu.GetCPU()}");
            _order.Computer.CPU = _oldCpu;
        }

        public string GetDescription()
        {
            return $"Upgrade CPU: {_oldCpu.GetCPU()} → {_newCpu.GetCPU()}";
        }
    }
}

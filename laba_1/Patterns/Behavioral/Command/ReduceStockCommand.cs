using System;
using Patterns.Behavioral.Observer;

namespace Patterns.Behavioral.Command
{
    /// <summary>
    /// Команда для зменшення кількості компонентів на складі
    /// </summary>
    public class ReduceStockCommand : ICommand
    {
        private readonly WarehouseWithObserver _warehouse;
        private readonly string _componentName;
        private readonly int _quantity;

        public ReduceStockCommand(WarehouseWithObserver warehouse, string componentName, int quantity = 1)
        {
            _warehouse = warehouse;
            _componentName = componentName;
            _quantity = quantity;
        }

        public void Execute()
        {
            for (int i = 0; i < _quantity; i++)
            {
                _warehouse.ReduceStock(_componentName);
            }
        }

        public void Undo()
        {
            _warehouse.AddStock(_componentName, _quantity);
        }

        public string GetDescription()
        {
            return $"Видання {_quantity} шт. '{_componentName}'";
        }
    }
}

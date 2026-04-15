using System;
using Patterns.Behavioral.Observer;

namespace Patterns.Behavioral.Command
{
    public class IncreaseStockCommand : ICommand
    {
        private readonly WarehouseWithObserver _warehouse;
        private readonly string _componentName;
        private readonly int _quantity;

        public IncreaseStockCommand(WarehouseWithObserver warehouse, string componentName, int quantity)
        {
            _warehouse = warehouse;
            _componentName = componentName;
            _quantity = quantity;
        }

        public void Execute()
        {
            _warehouse.AddStock(_componentName, _quantity);
        }

        public void Undo()
        {
            for (int i = 0; i < _quantity; i++)
            {
                _warehouse.ReduceStock(_componentName);
            }
        }

        public string GetDescription()
        {
            return $"Поповнення '{_componentName}' на {_quantity} шт.";
        }
    }
}

using System;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Command
{
    public class ProcessOrderCommand : ICommand
    {
        private readonly Order _order;
        private readonly string _actionName;

        public ProcessOrderCommand(Order order, string actionName)
        {
            _order = order;
            _actionName = actionName;
        }

        public void Execute()
        {
            switch (_actionName)
            {
                case "process":
                    _order.Process();
                    break;
                case "ship":
                    _order.Ship();
                    break;
                case "deliver":
                    _order.Deliver();
                    break;
                case "cancel":
                    _order.Cancel();
                    break;
            }
        }

        public void Undo()
        {
            Console.WriteLine($"Скасування операції над замовленням не можливе (стан матиме наслідки)");
        }

        public string GetDescription()
        {
            return $"Операція '{_actionName}' над замовленням {_order.OrderId}";
        }
    }
}

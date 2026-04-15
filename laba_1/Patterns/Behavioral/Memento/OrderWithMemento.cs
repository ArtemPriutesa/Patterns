using System;
using Patterns.Model;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Memento
{
    public class OrderWithMemento : Order
    {
        private readonly OrderMementoCaretaker _caretaker = new();

        public OrderWithMemento(string orderId, Computer computer) 
            : base(orderId, computer)
        {
        }

        public void SaveCheckpoint()
        {
            var memento = new OrderMemento(OrderId, Computer, CurrentState, CreatedDate);
            _caretaker.SaveCheckpoint(memento);
        }

        public void RestorePreviousCheckpoint()
        {
            var memento = _caretaker.GoToPreviousCheckpoint();
            if (memento != null)
            {
                RestoreFromMemento(memento);
            }
        }

        public void RestoreNextCheckpoint()
        {
            var memento = _caretaker.GoToNextCheckpoint();
            if (memento != null)
            {
                RestoreFromMemento(memento);
            }
        }

        public void RestoreCheckpoint(int index)
        {
            var memento = _caretaker.GetCheckpoint(index);
            if (memento != null)
            {
                RestoreFromMemento(memento);
            }
        }

        private void RestoreFromMemento(OrderMemento memento)
        {
            Console.WriteLine($"Відновлення замовлення до стану: {memento.StateType}");

            if (memento.StateType.Contains("Очікування"))
            {
                CurrentState = new PendingOrderState();
            }
            else if (memento.StateType.Contains("Обробляється"))
            {
                CurrentState = new ProcessingOrderState();
            }
            else if (memento.StateType.Contains("В дорозі"))
            {
                CurrentState = new ShippedOrderState();
            }
            else if (memento.StateType.Contains("Доставлено"))
            {
                CurrentState = new DeliveredOrderState();
            }
            else if (memento.StateType.Contains("Скасовано"))
            {
                CurrentState = new CancelledOrderState();
            }
        }

        public void DisplayCheckpointHistory()
        {
            _caretaker.DisplayCheckpointHistory();
        }

        public int GetCheckpointCount() => _caretaker.GetCheckpointCount();
    }
}

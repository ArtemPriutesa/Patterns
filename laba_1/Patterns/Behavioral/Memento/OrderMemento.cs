using System;
using Patterns.Model;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Memento
{
    public class OrderMemento
    {
        public string OrderId { get; private set; }
        public Computer Computer { get; private set; }
        public string StateType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime SavedAt { get; private set; }

        public OrderMemento(string orderId, Computer computer, IOrderState state, DateTime createdAt)
        {
            OrderId = orderId;
            Computer = computer;
            StateType = state.GetStatus();
            CreatedAt = createdAt;
            SavedAt = DateTime.Now;
        }

        public void DisplayMemento()
        {
            Console.WriteLine($"  Snapshot: {OrderId}");
            Console.WriteLine($"  Стан: {StateType}");
            Console.WriteLine($"  Збережено: {SavedAt:dd.MM.yyyy HH:mm:ss}");
        }
    }
}

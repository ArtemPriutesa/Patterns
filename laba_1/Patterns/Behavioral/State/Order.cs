using System;
using Patterns.Model;

namespace Patterns.Behavioral.State
{
    public class Order
    {
        public string OrderId { get; private set; }
        public Computer Computer { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public IOrderState CurrentState { get; set; }

        public Order(string orderId, Computer computer)
        {
            OrderId = orderId;
            Computer = computer;
            CreatedDate = DateTime.Now;
            CurrentState = new PendingOrderState();
        }

        public void Process()
        {
            Console.WriteLine($"[Замовлення {OrderId}] {CurrentState.GetStatus()}");
            CurrentState.Process(this);
        }

        public void Ship()
        {
            Console.WriteLine($"[Замовлення {OrderId}] {CurrentState.GetStatus()}");
            CurrentState.Ship(this);
        }

        public void Deliver()
        {
            Console.WriteLine($"[Замовлення {OrderId}] {CurrentState.GetStatus()}");
            CurrentState.Deliver(this);
        }

        public void Cancel()
        {
            Console.WriteLine($"[Замовлення {OrderId}] {CurrentState.GetStatus()}");
            CurrentState.Cancel(this);
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"  Замовлення: {OrderId}");
            Console.WriteLine($"  Комп'ютер: {Computer}");
            Console.WriteLine($"  Стан: {CurrentState.GetStatus()}");
            Console.WriteLine($"  Дата: {CreatedDate:dd.MM.yyyy HH:mm}");
        }
    }
}

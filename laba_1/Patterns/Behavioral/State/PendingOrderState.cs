using System;

namespace Patterns.Behavioral.State
{
    public class PendingOrderState : IOrderState
    {
        public void Process(Order order)
        {
            Console.WriteLine(" Замовлення обробляється...");
            order.CurrentState = new ProcessingOrderState();
        }

        public void Ship(Order order)
        {
            Console.WriteLine(" Неможливо відправити - замовлення ще не обробляється!");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine(" Неможливо доставити - замовлення ще не готове!");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine(" Замовлення скасовано");
            order.CurrentState = new CancelledOrderState();
        }

        public string GetStatus() => "Очікування";
    }
}

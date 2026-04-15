using System;

namespace Patterns.Behavioral.State
{
    public class ShippedOrderState : IOrderState
    {
        public void Process(Order order)
        {
            Console.WriteLine(" Неможливо обробити - замовлення вже в дорозі!");
        }

        public void Ship(Order order)
        {
            Console.WriteLine("  Замовлення вже відправлено");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine(" Замовлення доставлено!");
            order.CurrentState = new DeliveredOrderState();
        }

        public void Cancel(Order order)
        {
            Console.WriteLine(" Неможливо скасувати - замовлення вже в дорозі!");
        }

        public string GetStatus() => "В дорозі";
    }
}

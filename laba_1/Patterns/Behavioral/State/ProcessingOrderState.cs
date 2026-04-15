using System;

namespace Patterns.Behavioral.State
{
    public class ProcessingOrderState : IOrderState
    {
        public void Process(Order order)
        {
            Console.WriteLine(" Замовлення вже обробляється");
        }

        public void Ship(Order order)
        {
            Console.WriteLine(" Замовлення відправлено!");
            order.CurrentState = new ShippedOrderState();
        }

        public void Deliver(Order order)
        {
            Console.WriteLine(" Неможливо доставити - замовлення ще в дорозі!");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine("Замовлення скасовано (вертаємо кошти)");
            order.CurrentState = new CancelledOrderState();
        }

        public string GetStatus() => " Обробляється";
    }
}

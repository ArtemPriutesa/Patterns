using System;

namespace Patterns.Behavioral.State
{
    public class DeliveredOrderState : IOrderState
    {
        public void Process(Order order)
        {
            Console.WriteLine("Неможливо обробити - замовлення вже доставлено!");
        }

        public void Ship(Order order)
        {
            Console.WriteLine("Неможливо відправити - замовлення вже доставлено!");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine("Замовлення вже доставлено");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine("Неможливо скасувати - замовлення вже доставлено!");
        }

        public string GetStatus() => "Доставлено";
    }
}

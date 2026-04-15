using System;

namespace Patterns.Behavioral.State
{
    public class CancelledOrderState : IOrderState
    {
        public void Process(Order order)
        {
            Console.WriteLine("   Неможливо обробити - замовлення скасоване!");
        }

        public void Ship(Order order)
        {
            Console.WriteLine("   Неможливо відправити - замовлення скасоване!");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine("   Неможливо доставити - замовлення скасоване!");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine("   Замовлення вже скасоване");
        }

        public string GetStatus() => " Скасовано";
    }
}

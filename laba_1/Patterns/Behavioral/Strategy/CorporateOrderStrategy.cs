using System;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Strategy
{
    public class CorporateOrderStrategy : IOrderProcessingStrategy
    {
        public string GetName() => "Корпоративне замовлення";

        public decimal CalculatePrice(decimal basePrice)
        {
            return basePrice * 0.85m;
        }

        public int GetProcessingDays() => 10;

        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"[Корпоративна стратегія]");
            Console.WriteLine("   Опис: Спеціальна обробка для бізнес-клієнтів");
            Console.WriteLine("   Це можуть бути фізичні серверні приміщення");
            Console.WriteLine("   Доставка: 10-12 робочих днів");
            Console.WriteLine("   Знижка: 15%");
            Console.WriteLine("   Сніжна гарантія: 3 роки + техпідтримка");
            Console.WriteLine("   Метод оплати: Рахунок, банківський переказ");
            order.Process();
        }
    }
}

using System;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Strategy
{
    public class RetailOrderStrategy : IOrderProcessingStrategy
    {
        public string GetName() => "Роздрібне замовлення";

        public decimal CalculatePrice(decimal basePrice)
        {
            return basePrice;
        }

        public int GetProcessingDays() => 5;

        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"[Роздрібна стратегія]");
            Console.WriteLine("   Опис: Стандартна обробка індивідуального замовлення");
            Console.WriteLine("   Доставка: 5-7 робочих днів");
            Console.WriteLine("   Сніжна гарантія: 1 рік");
            Console.WriteLine("   Метод оплати: Кредитна карта, PayPal");
            order.Process();
        }
    }
}

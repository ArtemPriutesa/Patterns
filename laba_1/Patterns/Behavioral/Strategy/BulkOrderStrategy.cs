using System;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Strategy
{
    public class BulkOrderStrategy : IOrderProcessingStrategy
    {
        private readonly int _quantity;

        public BulkOrderStrategy(int quantity)
        {
            _quantity = quantity;
        }

        public string GetName() => "Оптове замовлення";

        public decimal CalculatePrice(decimal basePrice)
        {
            if (_quantity >= 50)
                return basePrice * 0.70m; 
                else if (_quantity >= 20)
                return basePrice * 0.80m; 
            else
                return basePrice * 0.90m; 
        }

        public int GetProcessingDays() => 14;

        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"[Оптова стратегія - {_quantity} одиниць]");
            Console.WriteLine($"  Опис: Оптова обробка великих замовлень");
            Console.WriteLine($"  Кількість: {_quantity} комп'ютерів");
            Console.WriteLine($"  Доставка: 2-3 тижні");
            
            decimal discount = (1 - CalculatePrice(100) / 100) * 100;
            Console.WriteLine($"  Знижка: {discount:F0}%");
            Console.WriteLine("  Гарантія: Індивідуальні умови");
            Console.WriteLine("  Метод оплати: Рахунок, фінансування доступне");
            order.Process();
        }
    }
}

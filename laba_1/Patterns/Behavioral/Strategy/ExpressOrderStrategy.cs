using System;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Strategy
{
    //Стратегія для експрес замовлення
    public class ExpressOrderStrategy : IOrderProcessingStrategy
    {
        public string GetName() => "Експрес замовлення";

        public decimal CalculatePrice(decimal basePrice)
        {
            return basePrice * 1.4m;
        }

        public int GetProcessingDays() => 1;

        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"[Экспрес стратегія]");
            Console.WriteLine("  Опис: Пріоритетна обробка та доставка");
            Console.WriteLine("  Доставка: 1-2 робочі дні");
            Console.WriteLine("  Сніжна гарантія: 1 рік");
            Console.WriteLine("  Додатково: Пакування із захистом");
            Console.WriteLine("  Метод оплати: Кредитна карта, мобільний платіж");
            Console.WriteLine("  Вартість: +40% до базової ціни");
            order.Process();
        }
    }
}

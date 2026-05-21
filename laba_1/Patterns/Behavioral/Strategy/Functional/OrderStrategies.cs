using System;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Strategy.Functional
{
    // Фабрика стратегій - статичні методи для створення стратегій
    public static class OrderStrategies
    {
        public static OrderStrategy Bulk(int quantity) => new(
            Name: "Оптове замовлення",
            CalculatePrice: basePrice => quantity switch
            {
                >= 50 => basePrice * 0.70m,
                >= 20 => basePrice * 0.80m,
                _ => basePrice * 0.90m
            },
            GetProcessingDays: () => 14,
            ProcessOrder: order =>
            {
                Console.WriteLine("[Оптова стратегія]");
                Console.WriteLine($"  Кількість: {quantity} одиниць");
                Console.WriteLine($"  Час обробки: 14 днів");
                Console.WriteLine($"  Знижка: {(1 - (quantity >= 50 ? 0.70m : quantity >= 20 ? 0.80m : 0.90m)) * 100}%");
                order.Process();
            }
        );

        public static OrderStrategy Express => new(
            Name: "Експрес замовлення",
            CalculatePrice: basePrice => basePrice * 1.4m,
            GetProcessingDays: () => 1,
            ProcessOrder: order =>
            {
                Console.WriteLine("[Експрес стратегія]");
                Console.WriteLine("  Опис: Пріоритетна обробка та доставка");
                Console.WriteLine("  Доставка: 1-2 робочі дні");
                Console.WriteLine("  Гарантія: 1 рік");
                Console.WriteLine("  Додатково: Пакування із захистом");
                Console.WriteLine("  Вартість: +40% до базової ціни");
                order.Process();
            }
        );

        public static OrderStrategy Retail => new(
            Name: "Роздрібне замовлення",
            CalculatePrice: basePrice => basePrice * 1.0m,
            GetProcessingDays: () => 5,
            ProcessOrder: order =>
            {
                Console.WriteLine("[Роздрібна стратегія]");
                Console.WriteLine("  Опис: Стандартна обробка");
                Console.WriteLine("  Доставка: 5-7 робочих днів");
                Console.WriteLine("  Гарантія: 6 місяців");
                Console.WriteLine("  Метод оплати: Будь-який");
                order.Process();
            }
        );

        public static OrderStrategy Corporate(int discount) => new(
            Name: "Корпоративне замовлення",
            CalculatePrice: basePrice => basePrice * (1 - discount / 100m),
            GetProcessingDays: () => 10,
            ProcessOrder: order =>
            {
                Console.WriteLine("[Корпоративна стратегія]");
                Console.WriteLine($"  Корпоративна знижка: {discount}%");
                Console.WriteLine("  Час обробки: 10 днів");
                Console.WriteLine("  Спеціальні умови: Можливе розстрочення платежу");
                order.Process();
            }
        );
    }
}

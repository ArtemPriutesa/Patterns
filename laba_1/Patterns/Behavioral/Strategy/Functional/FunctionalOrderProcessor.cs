using System;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Strategy.Functional
{
    public class FunctionalOrderProcessor
    {
        private OrderStrategy _strategy;
        private readonly decimal _basePrice;

        public FunctionalOrderProcessor(OrderStrategy strategy, decimal basePrice)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
            _basePrice = basePrice;
        }

        public void SetStrategy(OrderStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public void ProcessOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            Console.WriteLine($"\n*** Обробка замовлення по стратегії: {_strategy.Name} ***\n");
            _strategy.ProcessOrder(order);
        }

        public void DisplayPriceCalculation()
        {
            var finalPrice = _strategy.CalculatePrice(_basePrice);
            var processingDays = _strategy.GetProcessingDays();
            var difference = finalPrice - _basePrice;
            var percentChange = (difference / _basePrice) * 100;

            Console.WriteLine($"\n=== Розрахунок ціни: {_strategy.Name} ===");
            Console.WriteLine($"  Базова ціна: ${_basePrice:F2}");
            
            if (difference > 0)
                Console.WriteLine($"  Додатковий збір: ${difference:F2} ({percentChange:F0}%)");
            else if (difference < 0)
                Console.WriteLine($"  Знижка: ${Math.Abs(difference):F2} ({Math.Abs(percentChange):F0}%)");
            else
                Console.WriteLine($"  Без змін");

            Console.WriteLine($"  Фінальна ціна: ${finalPrice:F2}");
            Console.WriteLine($"  Час обробки: {processingDays} днів\n");
        }
    }
}

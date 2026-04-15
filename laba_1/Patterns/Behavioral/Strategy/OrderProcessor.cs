using System;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Strategy
{
    public class OrderProcessor
    {
        private IOrderProcessingStrategy _strategy;
        private decimal _basePrice;

        public OrderProcessor(IOrderProcessingStrategy strategy, decimal basePrice)
        {
            _strategy = strategy;
            _basePrice = basePrice;
        }

        public void SetStrategy(IOrderProcessingStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"\n*** Обробка замовлення по стратегії: {_strategy.GetName()} ***\n");
            
            _strategy.ProcessOrder(order);
        }

        public void DisplayPriceCalculation()
        {
            decimal finalPrice = _strategy.CalculatePrice(_basePrice);
            decimal discount = _basePrice - finalPrice;
            int processingDays = _strategy.GetProcessingDays();

            Console.WriteLine($"\n Розрахунок ціни:");
            Console.WriteLine($"   Базова ціна: ${_basePrice}");
            if (discount != 0)
            {
                Console.WriteLine($"Знижка: ${discount} ({(discount / _basePrice * 100):F0}%)");
            }
            else
            {
                Console.WriteLine($"Додатковий збір: ${_basePrice * (_strategy.CalculatePrice(100) / 100 - 1)}");
            }
            Console.WriteLine($"   Фінальна ціна: ${finalPrice}");
            Console.WriteLine($"   Час обробки: {processingDays} днів");
        }
    }
}

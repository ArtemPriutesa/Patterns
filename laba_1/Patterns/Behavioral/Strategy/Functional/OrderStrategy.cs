using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Strategy.Functional
{
    // Функціональна версія стратегії як record
    public record OrderStrategy(
        string Name,
        Func<decimal, decimal> CalculatePrice,
        Func<int> GetProcessingDays,
        Action<Order> ProcessOrder
    );
}

using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Strategy
{
    public interface IOrderProcessingStrategy
    {
        string GetName();
        decimal CalculatePrice(decimal basePrice);
        int GetProcessingDays();
        void ProcessOrder(Order order);
    }
}

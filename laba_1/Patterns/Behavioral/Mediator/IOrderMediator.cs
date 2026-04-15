using Patterns.Behavioral.State;
using Patterns.Behavioral.Memento;

namespace Patterns.Behavioral.Mediator
{
    public interface IOrderMediator
    {
        void ProcessOrder(OrderRequest request);
        void NotifyOrderStatusChanged(string orderId, string newStatus);
        void RequestStockReservation(string componentName, int quantity);
        void RequestPayment(string orderId, decimal amount);
        void NotifyCompletionCommand(string orderId);
    }
}

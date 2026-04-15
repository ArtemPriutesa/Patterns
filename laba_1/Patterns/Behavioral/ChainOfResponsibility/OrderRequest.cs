using Patterns.Behavioral.State;

namespace Patterns.Behavioral.ChainOfResponsibility
{
    public class OrderRequest
    {
        public Order Order { get; set; }
        public decimal Amount { get; set; }
        public bool HasPayment { get; set; }
        public bool IsValidated { get; set; }
        public bool IsStockReserved { get; set; }
        public bool IsReadyToShip { get; set; }

        public OrderRequest(Order order, decimal amount)
        {
            Order = order;
            Amount = amount;
            HasPayment = false;
            IsValidated = false;
            IsStockReserved = false;
            IsReadyToShip = false;
        }
    }
}

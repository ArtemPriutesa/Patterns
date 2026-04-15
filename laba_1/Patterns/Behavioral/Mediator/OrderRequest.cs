namespace Patterns.Behavioral.Mediator
{
    
    public class OrderRequest
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string ComponentName { get; set; }
        public int Quantity { get; set; }

        public OrderRequest(string orderId, decimal amount, string componentName, int quantity)
        {
            OrderId = orderId;
            Amount = amount;
            ComponentName = componentName;
            Quantity = quantity;
        }
    }
}

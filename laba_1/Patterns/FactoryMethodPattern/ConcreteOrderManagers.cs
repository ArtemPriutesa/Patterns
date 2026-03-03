namespace Patterns.FactoryMethodPattern
{
    public class RetailOrderManager : OrderManager
    {
        public override IInvoice CreateInvoice() => new RetailInvoice();
    }

    public class CorporateOrderManager : OrderManager
    {
        public override IInvoice CreateInvoice() => new CorporateInvoice();
    }
}

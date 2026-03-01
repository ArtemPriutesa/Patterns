using laba_1.creational.FactoryMethod;

namespace laba_1.creational.FactoryMethod
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
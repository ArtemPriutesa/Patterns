using Patterns.Model;

namespace Patterns.FactoryMethodPattern.Functional
{
    // Параметризована фабрика
    public static class AdvancedInvoiceFactories
    {
        // Фабрика з конфігурацією
        public static Func<IInvoice> CreateFactory(
            string invoiceType,
            decimal? discount = null,
            bool isPriority = false)
        {
            return invoiceType.ToLower() switch
            {
                "retail" => () => new RetailInvoice(),
                
                "corporate" => () => CreateCorporateWithOptions(discount, isPriority),
                
                "vip" => () => CreateVipInvoice(discount ?? 0),
                
                _ => () => new RetailInvoice()
            };
        }

        private static IInvoice CreateCorporateWithOptions(decimal? discount, bool isPriority)
        {
            Console.WriteLine(isPriority ? "  [VIP обробка]" : "  [Стандартна обробка]");
            if (discount.HasValue)
                Console.WriteLine($"  Знижка: {discount}%");
            return new CorporateInvoice();
        }

        private static IInvoice CreateVipInvoice(decimal discount)
        {
            Console.WriteLine($"  [VIP статус, знижка {discount}%]");
            return new CorporateInvoice();
        }
    }

    public class AdvancedOrderProcessor
    {
        private readonly Func<IInvoice> _invoiceFactory;

        public AdvancedOrderProcessor(
            string invoiceType,
            decimal? discount = null,
            bool isPriority = false)
        {
            _invoiceFactory = AdvancedInvoiceFactories.CreateFactory(
                invoiceType, 
                discount, 
                isPriority
            );
        }

        public void ProcessOrder(Computer pc)
        {
            Console.WriteLine("Обробка замовлення...");
            System.Threading.Thread.Sleep(500);
            var invoice = _invoiceFactory();
            invoice.Print(pc);
        }
    }
}

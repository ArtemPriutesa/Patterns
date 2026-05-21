using Patterns.Model;

namespace Patterns.FactoryMethodPattern.Functional
{
    // Делегат - "контракт" для фабрики
    public delegate IInvoice InvoiceFactory();

    // Функції-фабрики (просто методи, без класів!)
    public static class InvoiceFactories
    {
        // Фабрика для роздрібних замовлень
        public static IInvoice CreateRetailInvoice() => new RetailInvoice();

        // Фабрика для корпоративних замовлень
        public static IInvoice CreateCorporateInvoice() => new CorporateInvoice();

        // Фабрика з параметрами
        public static IInvoice CreateSpecialInvoice(bool isPriority)
        {
            return isPriority 
                ? new CorporateInvoice()  // Преміум опрацювання
                : new RetailInvoice();    // Стандартне опрацювання
        }
    }

    // Процесор, що використовує функцію-фабрику
    public class FunctionalOrderProcessor
    {
        private readonly InvoiceFactory _invoiceFactory;

        // Ін'єкція фабрики як функції!
        public FunctionalOrderProcessor(InvoiceFactory invoiceFactory)
        {
            _invoiceFactory = invoiceFactory ?? throw new ArgumentNullException(nameof(invoiceFactory));
        }

        public void ProcessOrder(Computer pc)
        {
            Console.WriteLine("Обробка замовлення...");
            System.Threading.Thread.Sleep(1000);
            
            // Використання фабрики
            var invoice = _invoiceFactory();
            invoice.Print(pc);
        }
    }
}

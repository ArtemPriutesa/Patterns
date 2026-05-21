using Patterns.Model;

namespace Patterns.FactoryMethodPattern.Functional
{
    // Record для інкапсуляції фабрики
    public record OrderContext(
        string Type,
        Func<IInvoice> CreateInvoice,
        Action<Computer> ProcessOrder
    );

    public static class OrderContextFactories
    {
        public static OrderContext Retail => new(
            Type: "Роздрібне",
            CreateInvoice: () => new RetailInvoice(),
            ProcessOrder: computer =>
            {
                Console.WriteLine("[Роздрібний замовник]");
                Console.WriteLine($"  Тип: Роздрібне замовлення");
                Console.WriteLine($"  Стандартна обробка");
                new RetailInvoice().Print(computer);
            }
        );

        public static OrderContext Corporate => new(
            Type: "Корпоративне",
            CreateInvoice: () => new CorporateInvoice(),
            ProcessOrder: computer =>
            {
                Console.WriteLine("[Корпоративний замовник]");
                Console.WriteLine($"  Тип: Корпоративне замовлення");
                Console.WriteLine($"  Пріоритетна обробка");
                new CorporateInvoice().Print(computer);
            }
        );

        public static OrderContext Express => new(
            Type: "Експрес",
            CreateInvoice: () => new CorporateInvoice(),
            ProcessOrder: computer =>
            {
                Console.WriteLine("[Експрес замовник]");
                Console.WriteLine($"  Тип: Експрес замовлення");
                Console.WriteLine($"  Миттєва обробка!");
                new CorporateInvoice().Print(computer);
            }
        );

        // Фабрика за типом
        public static OrderContext CreateByType(string type) =>
            type.ToLower() switch
            {
                "retail" => Retail,
                "corporate" => Corporate,
                "express" => Express,
                _ => Retail  // За замовчуванням
            };
    }

    public class ContextBasedOrderProcessor
    {
        private readonly OrderContext _context;

        public ContextBasedOrderProcessor(OrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void ProcessOrder(Computer pc)
        {
            _context.ProcessOrder(pc);
        }
    }
}

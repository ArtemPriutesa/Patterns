using Patterns.Model;

namespace Patterns.FactoryMethodPattern.Functional
{
    // Реєстр фабрик
    public class InvoiceFactoryRegistry
    {
        private readonly Dictionary<string, Func<IInvoice>> _factories;

        public InvoiceFactoryRegistry()
        {
            _factories = new Dictionary<string, Func<IInvoice>>(StringComparer.OrdinalIgnoreCase)
            {
                { "retail", () => new RetailInvoice() },
                { "corporate", () => new CorporateInvoice() },
                { "express", () => new CorporateInvoice() },
            };
        }

        // Реєстрація нової фабрики
        public void Register(string key, Func<IInvoice> factory)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Ключ фабрики не може бути порожнім");
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));
                
            _factories[key] = factory;
        }

        // Отримання фабрики
        public Func<IInvoice> Get(string key)
        {
            if (_factories.TryGetValue(key, out var factory))
                return factory;
            
            throw new ArgumentException($"Фабрика '{key}' не знайдена");
        }

        // Список всіх типів
        public IEnumerable<string> GetAvailableTypes() => _factories.Keys;

        // Перевірка наявності типу
        public bool Contains(string key) => _factories.ContainsKey(key);
    }

    public class RegistryBasedOrderProcessor
    {
        private readonly InvoiceFactoryRegistry _registry;
        private string _selectedType;

        public RegistryBasedOrderProcessor(InvoiceFactoryRegistry registry, string defaultType = "retail")
        {
            _registry = registry ?? throw new ArgumentNullException(nameof(registry));
            
            if (!_registry.Contains(defaultType))
                throw new ArgumentException($"Тип '{defaultType}' не зареєстрований");
            
            _selectedType = defaultType;
        }

        public void SetInvoiceType(string type)
        {
            if (!_registry.Contains(type))
                throw new ArgumentException($"Тип '{type}' не зареєстрований");
            
            _selectedType = type;
        }

        public void ProcessOrder(Computer pc)
        {
            Console.WriteLine($"Обробка замовлення (тип: {_selectedType})...");
            System.Threading.Thread.Sleep(500);
            var factory = _registry.Get(_selectedType);
            var invoice = factory();
            invoice.Print(pc);
        }

        public void ShowAvailableTypes()
        {
            Console.WriteLine("Доступні типи замовлень:");
            foreach (var type in _registry.GetAvailableTypes())
                Console.WriteLine($"  - {type}");
        }
    }
}

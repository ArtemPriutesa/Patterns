using System;
using Patterns.Model;
using Patterns.AbstractFactoryPattern;
using Patterns.BuilderPattern;
using Patterns.FactoryMethodPattern;
using Patterns.SingletonPattern;
using Patterns.FactoryPattern;
using Patterns.Structural;
using Patterns.Behavioral.Observer;
using Patterns.Behavioral.State;
using Patterns.Behavioral.ChainOfResponsibility;
using Patterns.Behavioral.Strategy;
using Patterns.Behavioral.Command;
using Patterns.Behavioral.Visitor;
using Patterns.Behavioral.Memento;
using Patterns.Behavioral.Mediator;
using Patterns.Behavioral.Iterator;
using Patterns.Behavioral.TemplateMethod;

static class Program
{
    static void Main()
    {
        Console.WriteLine("=== ДЕМОНСТРАЦІЯ ПАТТЕРНІВ ===\n");

        Console.WriteLine("1. Абстрактна фабрика");
        IPcFactory intelFactory = new IntelFactory();
        var intelCpu = intelFactory.CreateCpu("Intel i9-14900K");
        var intelMB = intelFactory.CreateMotherboard("LGA1700");
        Console.WriteLine($"Intel CPU: {intelCpu.GetCPU()}");
        Console.WriteLine($"Intel Motherboard: {intelMB.GetMotherboard()}\n");

        Console.WriteLine("2. Проста фабрика");
        var peripheralFactory = new PeripheralFactory();
        var mouse = peripheralFactory.CreatePeripheral("mouse");
        Console.WriteLine($"Peripheral: {mouse.GetInfo()}\n");

        Console.WriteLine("3. Будівник");
        var builder = new ComputerBuilder(intelFactory);
        var gamingPc = builder
            .BuildCPU("Intel i7-14700K")
            .BuildMotherboard("Z790")
            .BuildRAM("32GB DDR5")
            .BuildGPU("RTX 4080")
            .GetComputer();
        Console.WriteLine($"ПК: {gamingPc}\n");

        Console.WriteLine("4. Синглтон");
        var warehouse = Warehouse.Instance;
        Console.WriteLine($"Склад доступний: {warehouse.IsAvailable("i9-14900K")}\n");

        Console.WriteLine("=== СТРУКТУРНІ ПАТТЕРНИ ===\n");

        Console.WriteLine("5. Адаптер");
        var oldProc = new OldServerProcessor();
        var cpuAdapter = new ServerCpuAdapter(oldProc);
        Console.WriteLine($"{cpuAdapter.GetCPU()}\n");

        Console.WriteLine("6. Міст");
        var gamingDesktop = new GamingDesktop(intelCpu, intelMB, "16GB DDR4", "RTX 3070");
        gamingDesktop.RunSystem();
        Console.WriteLine();

        Console.WriteLine("7. Композит");
        var hardwareGroup = new HardwareGroup("Gaming Setup");
        hardwareGroup.AddComponent(intelCpu);
        hardwareGroup.AddComponent(intelMB);
        hardwareGroup.DisplayDetails(0);
        Console.WriteLine($"Ціна: ${hardwareGroup.GetPrice()}\n");

        Console.WriteLine("8. Декоратор");
        var overclockedCpu = new OverclockedCpu(intelCpu);
        Console.WriteLine(overclockedCpu.GetCPU());
        Console.WriteLine($"Ціна: ${overclockedCpu.GetPrice()}\n");

        Console.WriteLine("9. Фасад");
        var diagnosticFacade = new DiagnosticFacade(intelCpu, intelMB);
        diagnosticFacade.RunDiagnostics();
        Console.WriteLine();

        Console.WriteLine("10. Легковаговик");
        var spec1 = new HardwareSpecs("i9-14900K", "Intel", "CPU");
        var spec2 = new HardwareSpecs("i9-14900K", "Intel", "CPU");
        Console.WriteLine($"Spec 1: {spec1}");
        Console.WriteLine($"Spec 2 (та сама пам'ять): {spec2}\n");

        Console.WriteLine("11. Проксі");
        var adminProxy = new WarehouseProxy("Admin");
        adminProxy.ReduceStock("i9-14900K");
        Console.WriteLine();

        Console.WriteLine("12. Фабричний метод");
        OrderManager retailManager = new RetailOrderManager();
        retailManager.ProcessOrder(gamingPc);
        Console.WriteLine();

        Console.WriteLine("=== ПОВЕДІНКОВІ ПАТТЕРНИ ===\n");

        Console.WriteLine("13. Спостерігач (Observer)");
        var warehouseObservable = WarehouseWithObserver.Instance;
        var notifier = new WarehouseNotifier("Менеджер");
        var stockAlert = new StockAlertObserver(minimumThreshold: 5);
        
        warehouseObservable.Subscribe(notifier);
        warehouseObservable.Subscribe(stockAlert);
        warehouseObservable.DisplayInventory();
        
        Console.WriteLine("14. Стан (State)");
        var order = new Order("ORD-001", gamingPc);
        order.DisplayStatus();
        Console.WriteLine("\nПереходи між станами:");
        order.Process();
        order.Ship();
        order.Deliver();
        Console.WriteLine();
        
        Console.WriteLine("15. Ланцюг відповідальності (Chain of Responsibility)");
        var validateHandler = new ValidateOrderHandler();
        var paymentHandler = new PaymentHandler();
        var stockHandler = new StockReservationHandler();
        var shippingHandler = new ShippingHandler();
        var notificationHandler = new NotificationHandler();
        
        validateHandler.SetNext(paymentHandler);
        paymentHandler.SetNext(stockHandler);
        stockHandler.SetNext(shippingHandler);
        shippingHandler.SetNext(notificationHandler);
        
        var chainOrder = new Order("ORD-100", gamingPc);
        var chainRequest = new Patterns.Behavioral.ChainOfResponsibility.OrderRequest(chainOrder, 1500m);
        validateHandler.Handle(chainRequest);
        Console.WriteLine();
        
        Console.WriteLine("16. Стратегія (Strategy)");
        decimal basePrice = 1500m;
        var retailStrategy = new RetailOrderStrategy();
        var retailOrder = new Order("ORD-RETAIL", gamingPc);
        var retailProcessor = new OrderProcessor(retailStrategy, basePrice);
        retailProcessor.ProcessOrder(retailOrder);
        retailProcessor.DisplayPriceCalculation();
        Console.WriteLine();
        
        Console.WriteLine("17. Команда (Command)");
        var warehouseCmd = WarehouseWithObserver.Instance;
        var invoker = new CommandInvoker();
        
        var cmd1 = new ReduceStockCommand(warehouseCmd, "i9-14900K", 2);
        invoker.ExecuteCommand(cmd1);
        var cmd2 = new IncreaseStockCommand(warehouseCmd, "RTX 4080", 5);
        invoker.ExecuteCommand(cmd2);
        
        invoker.DisplayHistory();
        Console.WriteLine();
        
        Console.WriteLine("18. Відвідувач (Visitor)");
        var gamingComp = new ComputerAssembly("Gaming PC");
        gamingComp.AddComponent(new ProcessorComponent("Intel i9-14900K", 589m));
        gamingComp.AddComponent(new MotherboardComponent("ASUS ROG Z790", 349m));
        gamingComp.AddComponent(new GraphicsComponent("RTX 4090", 1599m));
        
        var priceVisitor = new PriceCalculatorVisitor();
        gamingComp.Accept(priceVisitor);
        priceVisitor.DisplayTotal();
        
        var specVisitor = new SpecificationVisitor();
        gamingComp.Accept(specVisitor);
        specVisitor.DisplaySpecifications();
        Console.WriteLine();
        
        Console.WriteLine("19. Мементо (Memento)");
        var mementoOrder = new OrderWithMemento("ORD-MEM-001", gamingPc);
        
        mementoOrder.DisplayStatus();
        mementoOrder.SaveCheckpoint();
        
        mementoOrder.Process();
        mementoOrder.SaveCheckpoint();
        
        mementoOrder.Ship();
        mementoOrder.SaveCheckpoint();
        
        mementoOrder.DisplayCheckpointHistory();
        Console.WriteLine();
        
        Console.WriteLine("20. Медіатор (Mediator)");
        var mediatorWarehouse = WarehouseWithObserver.Instance;
        var paymentService = new PaymentService(null!);
        var notificationService = new NotificationService(null!);
        var compatibilityChecker = new CompatibilityChecker(null!);
        
        var mediator = new OrderProcessingMediator(
            mediatorWarehouse,
            paymentService,
            notificationService,
            compatibilityChecker);
        
        var mediatorRequest = new Patterns.Behavioral.Mediator.OrderRequest("ORD-MED-001", 1500m, "i9-14900K", 1);
        mediator.ProcessOrder(mediatorRequest);
        Console.WriteLine();
        
        Console.WriteLine("21. Ітератор (Iterator)");
        var history = new CommandHistory();
        
        var iterCmd1 = new ReduceStockCommand(warehouseCmd, "i9-14900K", 1);
        var iterCmd2 = new IncreaseStockCommand(warehouseCmd, "RTX 4080", 2);
        var iterCmd3 = new ReduceStockCommand(warehouseCmd, "32GB DDR5", 1);
        
        history.AddCommand(iterCmd1);
        history.AddCommand(iterCmd2);
        history.AddCommand(iterCmd3);
        
        var iterator = history.CreateIterator();
        int commandNumber = 1;
        while (iterator.HasNext())
        {
            var cmd = iterator.Next();
            Console.WriteLine($"  {commandNumber}. {cmd.GetDescription()}");
            commandNumber++;
        }
        Console.WriteLine();
        
        Console.WriteLine("22. Шаблонний метод (Template Method)");
        var gamingAssembly = new GamingComputerAssembly();
        gamingAssembly.AssembleComputer("Gaming PC RTX 4090");
    }
}
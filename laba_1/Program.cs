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
        Console.WriteLine("Демонстрацяія патернів\n");

        Console.WriteLine("Абстрактна фабрика");
        IPcFactory intelFactory = new IntelFactory();
        var intelCpu = intelFactory.CreateCpu("Intel i9-14900K");
        var intelMB = intelFactory.CreateMotherboard("LGA1700");
        Console.WriteLine($"Intel: {intelCpu.GetCPU()}");
        Console.WriteLine($"Intel: {intelMB.GetMotherboard()}\n");

        IPcFactory amdFactory = new AmdFactory();
        var amdCpu = amdFactory.CreateCpu("AMD Ryzen 9 7950X");
        var amdMB = amdFactory.CreateMotherboard("AM5");
        Console.WriteLine($"AMD: {amdCpu.GetCPU()}");
        Console.WriteLine($"AMD: {amdMB.GetMotherboard()}\n");

        Console.WriteLine("Проста фабрика");
        var peripheralFactory = new PeripheralFactory();
        var mouse = peripheralFactory.CreatePeripheral("mouse");
        var keyboard = peripheralFactory.CreatePeripheral("keyboard");
        Console.WriteLine(mouse.GetInfo());
        Console.WriteLine(keyboard.GetInfo() + "\n");

        
        Console.WriteLine("Будівник");
        var builder = new ComputerBuilder(intelFactory);
        var gamingPc = builder
            .BuildCPU("Intel i7-14700K")
            .BuildMotherboard("Z790")
            .BuildRAM("32GB DDR5")
            .BuildGPU("RTX 4080")
            .GetComputer();
        Console.WriteLine($"Gaming PC: {gamingPc}\n");

        
        Console.WriteLine("Cінгелтон");
        var warehouse = Warehouse.Instance;
        Console.WriteLine($"Склад доступний: {warehouse.IsAvailable("i9-14900K")}\n");

        Console.WriteLine("Структурні патерни\n");

        Console.WriteLine("Адаптер");
        var oldProc = new OldServerProcessor();
        var cpuAdapter = new ServerCpuAdapter(oldProc);
        Console.WriteLine(cpuAdapter.GetCPU());
        Console.WriteLine();

        Console.WriteLine("Міст");
        var gamingDesktop = new GamingDesktop(intelCpu, intelMB, "16GB DDR4", "RTX 3070");
        gamingDesktop.RunSystem();
        var serverNode = new ServerNode(amdCpu, amdMB, "64GB DDR4", "No GPU");
        serverNode.RunSystem();
        Console.WriteLine();

        Console.WriteLine("Композит");
        var hardwareGroup = new HardwareGroup("Gaming Setup");
        hardwareGroup.AddComponent(intelCpu);
        hardwareGroup.AddComponent(intelMB);
        hardwareGroup.DisplayDetails(0);
        Console.WriteLine($"Total price: ${hardwareGroup.GetPrice()}");
        Console.WriteLine();

        Console.WriteLine("Декоратор");
        var overclockedCpu = new OverclockedCpu(intelCpu);
        Console.WriteLine(overclockedCpu.GetCPU());
        Console.WriteLine($"Price: ${overclockedCpu.GetPrice()}");
        Console.WriteLine();

        Console.WriteLine("Фасад");
        var diagnosticFacade = new DiagnosticFacade(intelCpu, intelMB);
        diagnosticFacade.RunDiagnostics();
        Console.WriteLine();

        Console.WriteLine("Легковаговик");
        var spec1 = new HardwareSpecs("i9-14900K", "Intel", "CPU");
        var spec2 = new HardwareSpecs("Ryzen 9 7950X", "AMD", "CPU");
        var spec3 = new HardwareSpecs("i9-14900K", "Intel", "CPU");
        Console.WriteLine($"Spec1: {spec1}");
        Console.WriteLine($"Spec2: {spec2}");
        Console.WriteLine($"Spec3: {spec3}");
        Console.WriteLine();

        Console.WriteLine("Проксі");
        var adminProxy = new WarehouseProxy("Admin");
        var userProxy = new WarehouseProxy("User");
        adminProxy.ReduceStock("i9-14900K");
        userProxy.ReduceStock("i9-14900K");
        Console.WriteLine();

        
        Console.WriteLine("Фабричний метод");
        OrderManager retailManager = new RetailOrderManager();
        retailManager.ProcessOrder(gamingPc);

        OrderManager corporateManager = new CorporateOrderManager();
        corporateManager.ProcessOrder(gamingPc);

        Console.WriteLine("\n\n=== ПОВЕДІНКОВІ ПАТЕРНИ ===\n");

        Console.WriteLine("Спостерігач (Observer)\n");
        
        // Отримуємо спостережуваний склад
        var warehouseObservable = WarehouseWithObserver.Instance;
        
        // Створюємо спостерігачів
        var notifier = new WarehouseNotifier("Менеджер складу");
        var stockAlert = new StockAlertObserver(minimumThreshold: 5);
        var analytics = new AnalyticsObserver();
        
        // Підписуємо спостерігачів на оновлення
        warehouseObservable.Subscribe(notifier);
        warehouseObservable.Subscribe(stockAlert);
        warehouseObservable.Subscribe(analytics);
        
        warehouseObservable.DisplayInventory();
        Console.WriteLine("\n--- Операції зі складом ---\n");
        
        // Операції - спостерігачі автоматично сповіщаються
        warehouseObservable.ReduceStock("RTX 4080");
        Console.WriteLine();
        
        warehouseObservable.ReduceStock("RTX 4080");
        Console.WriteLine();
        
        warehouseObservable.ReduceStock("RTX 4080");
        Console.WriteLine();
        
        warehouseObservable.ReduceStock("RTX 4080");
        Console.WriteLine();
        
        warehouseObservable.ReduceStock("RTX 4080");
        Console.WriteLine();
        
        // Критичний запас - спостерігач StockAlertObserver видасть попередження
        warehouseObservable.ReduceStock("RTX 4080");
        Console.WriteLine();
        
        // Поповнення запасу
        Console.WriteLine("\n--- Поповнення запасу ---\n");
        warehouseObservable.AddStock("RTX 4080", 10);
        Console.WriteLine();
        
        // Можемо відписати спостерігача
        Console.WriteLine("--- Відписування спостерігача ---\n");
        warehouseObservable.Unsubscribe(notifier);
        
        warehouseObservable.ReduceStock("i9-14900K");
        Console.WriteLine("(Менеджер складу більше не отримує сповіщення)\n");
        
        // Аналітичний звіт
        analytics.PrintReport();

        Console.WriteLine("\n\n=== СТАН (STATE) ===\n");
        
        // Створюємо замовлення
        var order = new Order("ORD-001", gamingPc);
        
        Console.WriteLine("--- Переходи між станами ---\n");
        order.DisplayStatus();
        
        Console.WriteLine("\n1. Обробка замовлення:");
        order.Process();
        
        Console.WriteLine("\n2. Отправка замовлення:");
        order.Ship();
        
        Console.WriteLine("\n3. Доставка замовлення:");
        order.Deliver();
        
        Console.WriteLine("\n4. Спроба отримати наступну операцію:");
        order.Deliver(); // Операція недозволена
        
        Console.WriteLine("\n\n--- Альтернативний сценарій: Скасування ---\n");
        
        var cancelledOrder = new Order("ORD-002", gamingPc);
        cancelledOrder.DisplayStatus();
        
        Console.WriteLine("\n1. Обробка замовлення:");
        cancelledOrder.Process();
        
        Console.WriteLine("\n2. Скасування замовлення:");
        cancelledOrder.Cancel();
        
        Console.WriteLine("\n3. Спроба відправити скасановане замовлення:");
        cancelledOrder.Ship(); // Операція недозволена
        
        cancelledOrder.DisplayStatus();

        Console.WriteLine("\n\n=== ЛАНЦЮГ ВІДПОВІДАЛЬНОСТІ (CHAIN OF RESPONSIBILITY) ===\n");
        
        // Створюємо ланцюг обробників
        var validateHandler = new ValidateOrderHandler();
        var paymentHandler = new PaymentHandler();
        var stockHandler = new StockReservationHandler();
        var shippingHandler = new ShippingHandler();
        var notificationHandler = new NotificationHandler();
        
        //Побудова ланцюга
        validateHandler.SetNext(paymentHandler);
        paymentHandler.SetNext(stockHandler);
        stockHandler.SetNext(shippingHandler);
        shippingHandler.SetNext(notificationHandler);
        
        Console.WriteLine("--- Сценарій 1: Успішна обробка замовлення ---\n");
        var successOrder = new Order("ORD-100", gamingPc);
        var chainSuccessRequest = new Patterns.Behavioral.ChainOfResponsibility.OrderRequest(successOrder, 1500m);
        validateHandler.Handle(chainSuccessRequest);
        
        Console.WriteLine("\n--- Сценарій 2: Невдалий платіж (пропускаємо резервування) ---\n");
        var failedOrder = new Order("ORD-101", gamingPc);
        var chainFailedRequest = new Patterns.Behavioral.ChainOfResponsibility.OrderRequest(failedOrder, -100m);
        validateHandler.Handle(chainFailedRequest);
        
        Console.WriteLine("\n--- Сценарій 3: Невалідне замовлення ---\n");
        var chainInvalidRequest = new Patterns.Behavioral.ChainOfResponsibility.OrderRequest(new Order("ORD-102", gamingPc), 0m);
        validateHandler.Handle(chainInvalidRequest);

        Console.WriteLine("\n\n=== СТРАТЕГІЯ (STRATEGY) ===\n");
        
        decimal basePrice = 1500m; 
        
        // Стратегія 1: Розрібне замовлення
        var retailStrategy = new RetailOrderStrategy();
        var retailOrder = new Order("ORD-RETAIL-001", gamingPc);
        var retailProcessor = new OrderProcessor(retailStrategy, basePrice);
        retailProcessor.ProcessOrder(retailOrder);
        retailProcessor.DisplayPriceCalculation();
        
        Console.WriteLine("\n" + new string('-', 50) + "\n");
        
        // Стратегія 2: Корпоративне замовлення
        var corporateStrategy = new CorporateOrderStrategy();
        var corporateOrder = new Order("ORD-CORP-001", gamingPc);
        var corporateProcessor = new OrderProcessor(corporateStrategy, basePrice);
        corporateProcessor.ProcessOrder(corporateOrder);
        corporateProcessor.DisplayPriceCalculation();
        
        Console.WriteLine("\n" + new string('-', 50) + "\n");
        
        // Динамічна зміна стратегії
        Console.WriteLine("--- Динамічна зміна стратегії під час виконання ---\n");
        
        var processor = new OrderProcessor(new RetailOrderStrategy(), basePrice);
        var dynamicOrder = new Order("ORD-DYNAMIC-001", gamingPc);
        
        Console.WriteLine("1. Початково: Розрібне замовлення");
        processor.DisplayPriceCalculation();
        
        Console.WriteLine("\n2. Змінюємо на експрес:");
        processor.SetStrategy(new ExpressOrderStrategy());
        processor.DisplayPriceCalculation();
        
        Console.WriteLine("\n\n=== КОМАНДА (COMMAND) ===\n");
        
        var warehouseCmd = WarehouseWithObserver.Instance;
        var invoker = new CommandInvoker();
        
        Console.WriteLine("--- Операції зі складом через команди ---\n");
        
        // Виконуємо декілька команд
        var cmd1 = new ReduceStockCommand(warehouseCmd, "i9-14900K", 2);
        invoker.ExecuteCommand(cmd1);
        
        var cmd2 = new ReduceStockCommand(warehouseCmd, "RTX 4080", 1);
        invoker.ExecuteCommand(cmd2);
        
        var cmd3 = new IncreaseStockCommand(warehouseCmd, "32GB DDR5", 5);
        invoker.ExecuteCommand(cmd3);
        
        Console.WriteLine();
        invoker.DisplayHistory();
        
        Console.WriteLine("\n--- Скасування (Undo) операцій ---\n");
        invoker.Undo();
        Console.WriteLine();
        invoker.Undo();
        Console.WriteLine();
        invoker.DisplayHistory();
        
        Console.WriteLine("\n--- Повторення (Redo) операцій ---\n");
        invoker.Redo();
        Console.WriteLine();
        invoker.DisplayHistory();
        
        Console.WriteLine("\n--- Операції над замовленням (часткова Undo поддержка) ---\n");
        var commandOrder = new Order("ORD-CMD-001", gamingPc);
        
        var processCmd = new ProcessOrderCommand(commandOrder, "process");
        invoker.ExecuteCommand(processCmd);
        
        Console.WriteLine();
        
        var shipCmd = new ProcessOrderCommand(commandOrder, "ship");
        invoker.ExecuteCommand(shipCmd);
        
        Console.WriteLine();
        invoker.DisplayHistory();

        Console.WriteLine("\n\n=== ВІДВІДУВАЧ (VISITOR) ===\n");
        
        // Створюємо конфігурацію комп'ютера
        var gamingComp = new ComputerAssembly("Gaming PC");
        gamingComp.AddComponent(new ProcessorComponent("Intel i9-14900K", 589m));
        gamingComp.AddComponent(new MotherboardComponent("ASUS ROG Z790", 349m));
        gamingComp.AddComponent(new GraphicsComponent("RTX 4090", 1599m));
        gamingComp.AddComponent(new MemoryComponent("Corsair DDR5", 249m, 32));
        
        Console.WriteLine($"--- Система: {gamingComp.GetName()} ({gamingComp.GetComponentCount()} компонентів) ---\n");
        
        // Відвідувач 1: Розрахунок вартості
        var priceVisitor = new PriceCalculatorVisitor();
        Console.WriteLine("Розрахунок вартості:");
        gamingComp.Accept(priceVisitor);
        priceVisitor.DisplayTotal();
        
        // Відвідувач 2: Специфікація
        var specVisitor = new SpecificationVisitor();
        gamingComp.Accept(specVisitor);
        specVisitor.DisplaySpecifications();
        
        Console.WriteLine("\n--- Бюджетна конфігурація ---\n");
        
        var budgetComp = new ComputerAssembly("Budget Office PC");
        budgetComp.AddComponent(new ProcessorComponent("Intel i5-13600K", 219m));
        budgetComp.AddComponent(new MotherboardComponent("MSI B660", 129m));
        budgetComp.AddComponent(new GraphicsComponent("Integrated Graphics", 0m));
        budgetComp.AddComponent(new MemoryComponent("Kingston DDR4", 59m, 16));
        
        Console.WriteLine($"Система: {budgetComp.GetName()} ({budgetComp.GetComponentCount()} компонентів)\n");
        
        var budgetPrice = new PriceCalculatorVisitor();
        Console.WriteLine("Розрахунок вартості:");
        budgetComp.Accept(budgetPrice);
        budgetPrice.DisplayTotal();
        
        
        var budgetSpec = new SpecificationVisitor();
        budgetComp.Accept(budgetSpec);
        budgetSpec.DisplaySpecifications();

        Console.WriteLine("\n\n=== МЕМЕНТО (MEMENTO) ===\n");
        
        // Створюємо замовлення з підтримкою контрольних точок
        var mementoOrder = new OrderWithMemento("ORD-MEM-001", gamingPc);
        
        Console.WriteLine("--- Переходи між станами з контрольними точками ---\n");
        
        // Стан 1: Очікування (Pending)
        Console.WriteLine("1. Стан: Очікування");
        mementoOrder.DisplayStatus();
        mementoOrder.SaveCheckpoint();
        
        // Стан 2: Обробляється (Processing)
        Console.WriteLine("\n2. Обробка замовлення:");
        mementoOrder.Process();
        mementoOrder.SaveCheckpoint();
        
        // Стан 3: В дорозі (Shipped)
        Console.WriteLine("\n3. Відправка замовлення:");
        mementoOrder.Ship();
        mementoOrder.SaveCheckpoint();
        
        // Стан 4: Доставлено (Delivered)
        Console.WriteLine("\n4. Доставка замовлення:");
        mementoOrder.Deliver();
        mementoOrder.SaveCheckpoint();
        
        // Показуємо історію
        mementoOrder.DisplayCheckpointHistory();
        
        // Навігація по контрольних точках
        Console.WriteLine("\n--- Навігація по історії ---\n");
        
        Console.WriteLine("Поточний стан: Доставлено");
        Console.WriteLine("\nПовернення на 2 кроки назад:");
        mementoOrder.RestorePreviousCheckpoint();
        Console.WriteLine($"Новий стан: {mementoOrder.CurrentState.GetStatus()}");
        
        
        // Прямо переходимо на контрольну точку
        Console.WriteLine("\n--- Прямий перехід до контрольної точки 1 (Очікування) ---\n");
        mementoOrder.RestoreCheckpoint(0);
        Console.WriteLine($"Стан: {mementoOrder.CurrentState.GetStatus()}");
        
        // Контрольні точки замовлення
        mementoOrder.DisplayCheckpointHistory();

        Console.WriteLine("\n\n=== МЕДІАТОР (MEDIATOR) ===\n");
        
        // Створюємо компоненти
        var mediatorWarehouse = WarehouseWithObserver.Instance;
        var paymentService = new PaymentService(null!);
        var notificationService = new NotificationService(null!);
        var compatibilityChecker = new CompatibilityChecker(null!);
        
        // Створюємо медіатор, який координує все
        var mediator = new OrderProcessingMediator(
            mediatorWarehouse,
            paymentService,
            notificationService,
            compatibilityChecker);
        
        Console.WriteLine("\n--- Успішна обробка замовлення через медіатор ---\n");
        
        var mediatorSuccessRequest = new Patterns.Behavioral.Mediator.OrderRequest("ORD-MED-001", 1500m, "i9-14900K", 1);
        mediator.ProcessOrder(mediatorSuccessRequest);
        
        Console.WriteLine("\n--- Невдала обробка: компоненти недоступні ---\n");
        
        for (int i = 0; i < 15; i++)
        {
            mediatorWarehouse.ReduceStock("i9-14900K");
        }
        
        var failedStockRequest = new Patterns.Behavioral.Mediator.OrderRequest("ORD-MED-002", 1500m, "i9-14900K", 1);
        mediator.ProcessOrder(failedStockRequest);
        
        Console.WriteLine("\n--- Невдала обробка: платіж відхилено ---\n");
        
        var failedPaymentRequest = new Patterns.Behavioral.Mediator.OrderRequest("ORD-MED-003", 2000m, "RTX 4080", 1);
        mediator.ProcessOrder(failedPaymentRequest);
        
        Console.WriteLine("\n--- Координація змін статусу ---\n");
        
        mediator.NotifyOrderStatusChanged("ORD-MED-001", "Processing");
        Console.WriteLine();
        mediator.NotifyOrderStatusChanged("ORD-MED-001", "Shipped");
        Console.WriteLine();
        mediator.NotifyCompletionCommand("ORD-MED-001");

        Console.WriteLine("\n\n=== ІТЕРАТОР (ITERATOR) ===\n");
        
        // Створюємо історію команд
        var history = new CommandHistory();
        
        // Додаємо команди в історію
        var iterCmd1 = new ReduceStockCommand(warehouseCmd, "i9-14900K", 1);
        var iterCmd2 = new IncreaseStockCommand(warehouseCmd, "RTX 4080", 2);
        var iterCmd3 = new ReduceStockCommand(warehouseCmd, "32GB DDR5", 1);
        
        history.AddCommand(iterCmd1);
        history.AddCommand(iterCmd2);
        history.AddCommand(iterCmd3);
        
        Console.WriteLine($"--- Історія команд ({history.GetCommandCount()} всього) ---\n");
        
        Console.WriteLine("Історія команд (від першої до останної):\n");
        var iterator = history.CreateIterator();
        int commandNumber = 1;
        while (iterator.HasNext())
        {
            var cmd = iterator.Next();
            Console.WriteLine($"  {commandNumber}. {cmd.GetDescription()}");
            commandNumber++;
        }
    
        
        Console.WriteLine("\n--- Фільтрований обхід (тільки команди видання) ---\n");
        var filterIterator = history.CreateIterator();
        Console.WriteLine("Усі команди видання компонентів:\n");
        commandNumber = 1;
        while (filterIterator.HasNext())
        {
            var cmd = filterIterator.Next();
            if (cmd.GetDescription().Contains("Видання"))
            {
                Console.WriteLine($"  {commandNumber}. {cmd.GetDescription()}");
                commandNumber++;
            }
        }

        Console.WriteLine("\n\n=== ШАБЛОННИЙ МЕТОД (TEMPLATE METHOD) ===\n");
        
        Console.WriteLine("--- Різні типи комп'ютерів, як збираються послідовно ---\n");
        
        // Тип 1: Ігровий ПК
        var gamingAssembly = new GamingComputerAssembly();
        gamingAssembly.AssembleComputer("Gaming Powerhouse RTX 4090");
        
        Console.WriteLine("\n" + new string('═', 60) + "\n");
        
        // Тип 2: Офісний ПК
        var officeAssembly = new OfficeComputerAssembly();
        officeAssembly.AssembleComputer("Office Budget PC");
        
        Console.WriteLine("\n" + new string('═', 60) + "\n");
        
        // Тип 3: Серверний ПК
        var serverAssembly = new ServerComputerAssembly();
        serverAssembly.AssembleComputer("Database Server Node");

    }
}
using System;
using Patterns.Model;
using Patterns.AbstractFactoryPattern;
using Patterns.BuilderPattern;
using Patterns.FactoryMethodPattern;
using Patterns.SingletonPattern;
using Patterns.FactoryPattern;
using Patterns.Structural;

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

        
        Console.WriteLine("фабричний метод");
        OrderManager retailManager = new RetailOrderManager();
        retailManager.ProcessOrder(gamingPc);

        OrderManager corporateManager = new CorporateOrderManager();
        corporateManager.ProcessOrder(gamingPc);
    }
}
using System;
using Patterns.Model;
using Patterns.AbstractFactoryPattern;
using Patterns.BuilderPattern;
using Patterns.FactoryMethodPattern;
using Patterns.SingletonPattern;
using Patterns.FactoryPattern;

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

        
        Console.WriteLine("сінгелтон");
        var warehouse = Warehouse.Instance;
        Console.WriteLine($"Склад доступний: {warehouse.IsAvailable("i9-14900K")}\n");

        
        Console.WriteLine("фабричний метод");
        OrderManager retailManager = new RetailOrderManager();
        retailManager.ProcessOrder(gamingPc);

        OrderManager corporateManager = new CorporateOrderManager();
        corporateManager.ProcessOrder(gamingPc);
    }
}
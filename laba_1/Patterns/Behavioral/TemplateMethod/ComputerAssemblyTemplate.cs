using System;

namespace Patterns.Behavioral.TemplateMethod
{
    public abstract class ComputerAssemblyTemplate
    {
        protected string ProcessorType { get; set; } = string.Empty;
        protected string MotherboardType { get; set; } = string.Empty;
        protected string MemoryType { get; set; } = string.Empty;
        protected string GraphicsType { get; set; } = string.Empty;
        protected decimal EstimatedPrice { get; set; }
        protected string AssemblyResult { get; set; } = string.Empty;

        public void AssembleComputer(string computerName)
        {
            Console.WriteLine($"\nРозпочинаємо збирання: {computerName}\n");
            Console.WriteLine("==================================================\n");
            
            SelectProcessor();
            Console.WriteLine();
            
            SelectMotherboard();
            Console.WriteLine();
            
            SelectMemory();
            Console.WriteLine();
            
            SelectGraphics();
            Console.WriteLine();
            
            TestCompatibility();
            Console.WriteLine();
            
            CalculatePrice();
            Console.WriteLine();
            
            GenerateReport();
            
            Console.WriteLine("\n==================================================");
            Console.WriteLine($"КОМП'ЮТЕР ГОТОВИЙ: {computerName}\n");
        }

        protected abstract void SelectProcessor();

        protected abstract void SelectMotherboard();

        protected abstract void SelectMemory();

        protected abstract void SelectGraphics();

        protected abstract void TestCompatibility();

        protected abstract void CalculatePrice();

        protected virtual void GenerateReport()
        {
            Console.WriteLine("КОНФІГУРАЦІЯ КОМП'ЮТЕРА:");
            Console.WriteLine($"  Процесор:    {ProcessorType}");
            Console.WriteLine($"  Матплата:    {MotherboardType}");
            Console.WriteLine($"  Пам'ять:      {MemoryType}");
            Console.WriteLine($"  Графіка:     {GraphicsType}");
            Console.WriteLine($"  Вартість:    ${EstimatedPrice}");
            
            if (!string.IsNullOrEmpty(AssemblyResult))
            {
                Console.WriteLine($"  Статус:      {AssemblyResult}");
            }
        }

        protected void PrintComponentInfo(string componentType, string componentName, decimal price)
        {
            Console.WriteLine($"  + {componentType}: {componentName} (${price})");
        }
    }
}

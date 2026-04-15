using System;

namespace Patterns.Behavioral.TemplateMethod
{
    public class GamingComputerAssembly : ComputerAssemblyTemplate
    {
        protected override void SelectProcessor()
        {
            ProcessorType = "Intel i9-14900K";
            Console.WriteLine("1. ВИБІР ПРОЦЕСОРА:");
            PrintComponentInfo("Процесор", "Intel i9-14900K (24 cores, 5.8GHz)", 589m);
            Console.WriteLine("     - Ідеально для ігор з максимальним FPS");
        }

        protected override void SelectMotherboard()
        {
            MotherboardType = "ASUS ROG Z790-E Gaming";
            Console.WriteLine("2. ВИБІР МАТПЛАТИ:");
            PrintComponentInfo("Матплата", "ASUS ROG Z790-E Gaming", 349m);
            Console.WriteLine("     - Підтримує максимальний розгін (OC)");
            Console.WriteLine("     - PCIe 5.0 для найшвидшої видеокарти");
        }

        protected override void SelectMemory()
        {
            MemoryType = "32GB Corsair DDR5 6000MHz";
            Console.WriteLine("3. ВИБІР ПАМ'ЯТІ:");
            PrintComponentInfo("ОЗУ", "32GB Corsair DDR5 6000MHz", 299m);
            Console.WriteLine("     - Достатньо для одночасного запуску багатьох програм");
            Console.WriteLine("     - Висока частота для оптимальної видаваченості");
        }

        protected override void SelectGraphics()
        {
            GraphicsType = "NVIDIA RTX 4090";
            Console.WriteLine("4. ВИБІР ГРАФІКИ:");
            PrintComponentInfo("Графічна карта", "NVIDIA RTX 4090 (24GB)", 1799m);
            Console.WriteLine("     - Топова карта для середньої-максимальної якості в будь-якій грі");
            Console.WriteLine("     - Підтримує Ray Tracing та DLSS 3");
        }

        protected override void TestCompatibility()
        {
            Console.WriteLine("5. ПЕРЕВІРКА СУМІСНОСТІ:");
            Console.WriteLine("  + LGA1700 сокет + Z790 чіпсет + DDR5 підтримка");
            Console.WriteLine("  + Блок живлення 850W (рекомендується)");
            Console.WriteLine("  + Система охолодження: 360mm AIO Cool Master");
            
            AssemblyResult = "Усі компоненти повністю сумісні";
            Console.WriteLine($"  >> {AssemblyResult}");
        }

        protected override void CalculatePrice()
        {
            EstimatedPrice = 589m + 349m + 299m + 1799m + 150m;
            
            Console.WriteLine("6. КАЛЬКУЛЯЦІЯ ВАРТОСТІ:");
            Console.WriteLine($"  Бюджет під ігри: ${EstimatedPrice}");
            Console.WriteLine("  Готівка за:     Ultra Settings @ 4K, 144+ FPS");
            Console.WriteLine($"  Резервування:   ${EstimatedPrice * 0.15m}");
        }

        protected override void GenerateReport()
        {
            base.GenerateReport();
            Console.WriteLine("\nРЕКОМЕНДОВАНА КОНФІГУРАЦІЯ ІГОР:");
            Console.WriteLine("  * Cyberpunk 2077:   Ultra, DLSS 3, Ray Tracing - 100+ FPS");
            Console.WriteLine("  * Starfield:        Ultra, 4K - 120 FPS");
            Console.WriteLine("  * The Last of Us:   Ultra, 60 FPS (легко)");
        }
    }
}

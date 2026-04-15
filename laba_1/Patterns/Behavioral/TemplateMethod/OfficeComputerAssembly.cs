using System;

namespace Patterns.Behavioral.TemplateMethod
{
    public class OfficeComputerAssembly : ComputerAssemblyTemplate
    {
        protected override void SelectProcessor()
        {
            ProcessorType = "Intel i5-13600K";
            Console.WriteLine("1. ВИБІР ПРОЦЕСОРА:");
            PrintComponentInfo("Процесор", "Intel i5-13600K (14 cores, 5.1GHz)", 219m);
            Console.WriteLine("     - Достатньо для Office, браузера, Zoom");
            Console.WriteLine("     - Економна енергоспоживання");
        }

        protected override void SelectMotherboard()
        {
            MotherboardType = "MSI B660 Pro";
            Console.WriteLine("2. ВИБІР МАТПЛАТИ:");
            PrintComponentInfo("Матплата", "MSI B660 Pro", 129m);
            Console.WriteLine("     - Надійна матплата від перевіреного виробника");
            Console.WriteLine("     - Гарантія 3+ роки");
        }

        protected override void SelectMemory()
        {
            MemoryType = "16GB Kingston DDR4 3200MHz";
            Console.WriteLine("3. ВИБІР ПАМ'ЯТІ:");
            PrintComponentInfo("ОЗУ", "16GB Kingston DDR4 3200MHz", 89m);
            Console.WriteLine("     - Достатньо для одночасного запуску 20+ вкладок Chrome");
            Console.WriteLine("     - Бюджетний варіант з хорошою стабільністю");
        }

        protected override void SelectGraphics()
        {
            GraphicsType = "Integrated Intel UHD Graphics 770";
            Console.WriteLine("4. ВИБІР ГРАФІКИ:");
            PrintComponentInfo("Графіка", "Intel UHD Graphics 770 (вбудована)", 0m);
            Console.WriteLine("     - Достатньо для відео, презентацій, фотографій");
            Console.WriteLine("     - Не потрібна окрема видеокарта (економія $300-400)");
        }

        protected override void TestCompatibility()
        {
            Console.WriteLine("5. ПЕРЕВІРКА СУМІСНОСТІ:");
            Console.WriteLine("  + LGA1700 сокет + B660 чіпсет + DDR4 підтримка");
            Console.WriteLine("  + Блок живлення 500W (більш ніж достатньо)");
            Console.WriteLine("  + Система охолодження: Кулер Noctua NH-U12S");
            
            AssemblyResult = "Бюджетна, надійна конфігурація";
            Console.WriteLine($"  >> {AssemblyResult}");
        }

        protected override void CalculatePrice()
        {
            EstimatedPrice = 219m + 129m + 89m + 0m + 50m;
            
            Console.WriteLine("6. КАЛЬКУЛЯЦІЯ ВАРТОСТІ:");
            Console.WriteLine($"  Бюджет офісу:   ${EstimatedPrice}");
            Console.WriteLine("  Готівка за:     3-5 років надійної роботи");
            Console.WriteLine($"  Економія:       приблизно $200+ проти базової гейм конфіги");
        }

        protected override void GenerateReport()
        {
            base.GenerateReport();
            Console.WriteLine("\nРЕКОМЕНДОВАНІ ЗАВДАННЯ:");
            Console.WriteLine("  * Microsoft Office");
            Console.WriteLine("  * Google Chrome з 20+ вкладками");
            Console.WriteLine("  * Zoom / Teams конференції");
            Console.WriteLine("  * Adobe Reader, Outlook, Slack");
        }
    }
}

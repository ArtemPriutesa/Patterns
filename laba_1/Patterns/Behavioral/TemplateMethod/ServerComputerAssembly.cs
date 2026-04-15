using System;

namespace Patterns.Behavioral.TemplateMethod
{
    public class ServerComputerAssembly : ComputerAssemblyTemplate
    {
        protected override void SelectProcessor()
        {
            ProcessorType = "AMD Ryzen 9 7950X (Pro)";
            Console.WriteLine("1. ВИБІР ПРОЦЕСОРА:");
            PrintComponentInfo("Процесор", "AMD Ryzen 9 7950X Pro (16 cores, 5.7GHz)", 599m);
            Console.WriteLine("     - Оптимізований для сервера та багатопотокових операцій");
            Console.WriteLine("     - ECC DRAM підтримка для корекції помилок");
        }

        protected override void SelectMotherboard()
        {
            MotherboardType = "ASUS ProArt B850-CREATOR";
            Console.WriteLine("2. ВИБІР МАТПЛАТИ:");
            PrintComponentInfo("Матплата", "ASUS ProArt B850-CREATOR (Server Grade)", 399m);
            Console.WriteLine("     - Дизайн для критичної надійності");
            Console.WriteLine("     - Розширена гарантія та IPMI для віддаленого керування");
        }

        protected override void SelectMemory()
        {
            MemoryType = "64GB Kingston ECC DDR5 Pro";
            Console.WriteLine("3. ВИБІР ПАМ'ЯТІ:");
            PrintComponentInfo("ОЗУ", "64GB Kingston ECC DDR5 Pro (4800MHz)", 899m);
            Console.WriteLine("     - ECC (Error Correcting Code) для запобігання помилкам");
            Console.WriteLine("     - Критично для баз даних та обробки даних");
        }

        protected override void SelectGraphics()
        {
            GraphicsType = "Без дискретної графіки (GPU не потрібна)";
            Console.WriteLine("4. ВИБІР ГРАФІКИ:");
            PrintComponentInfo("GPU", "Без (серверні програми не потребують)", 0m);
            Console.WriteLine("     - Сервери зазвичай керуються через SSH/RDP");
            Console.WriteLine("     - Економія енергії та охолодження");
        }

        protected override void TestCompatibility()
        {
            Console.WriteLine("5. ПЕРЕВІРКА СУМІСНОСТІ:");
            Console.WriteLine("  + AM5 сокет + B850 чіпсет + ECC DDR5 підтримка");
            Console.WriteLine("  + Блок живлення 1200W 80+ Platinum (надійна якість)");
            Console.WriteLine("  + Система охолодження: Noctua NH-U14S TR4-SP3");
            Console.WriteLine("  + Сховище: 2x 2TB NVMe RAID 1 (дублювання для безпеки)");
            
            AssemblyResult = "Серверна конфігурація для критичних систем";
            Console.WriteLine($"  >> {AssemblyResult}");
        }

        protected override void CalculatePrice()
        {
            EstimatedPrice = 599m + 399m + 899m + 0m + 400m;
            
            Console.WriteLine("6. КАЛЬКУЛЯЦІЯ ВАРТОСТІ:");
            Console.WriteLine($"  Капітальні вклади: ${EstimatedPrice}");
            Console.WriteLine("  Річна вартість:    приблизно $50-200 (електро + підтримка)");
            Console.WriteLine("  ROI:                Окупується за 1-2 роки інтенсивного використання");
        }

        protected override void GenerateReport()
        {
            base.GenerateReport();
            Console.WriteLine("\nРЕКОМЕНДОВАНІ ВИКОРИСТАННЯ:");
            Console.WriteLine("  * Database Server (MySQL, PostgreSQL) - 24/7");
            Console.WriteLine("  * Web Server (nginx, Apache) - висока навантаження");
            Console.WriteLine("  * Machine Learning Pipeline - масштабне навчання");
            Console.WriteLine("  * File Server з RAID для багатьох користувачів");
            Console.WriteLine("  * Virtual Machine Host - ESXi/Proxmox кластер");
        }
    }
}

using System;

namespace Patterns.Behavioral.ChainOfResponsibility
{
    /// <summary>
    /// Обробник резервування компонентів на складі
    /// </summary>
    public class StockReservationHandler : OrderHandler
    {
        public override void Handle(OrderRequest request)
        {
            if (!request.HasPayment)
            {
                Console.WriteLine("[Резервування Складу]  Платіж не здійснений - пропускаємо резервування");
                return;
            }

            Console.WriteLine("[Резервування Компонентів на Складі]");
            
            // Імітуємо резервування
            Console.WriteLine("  Перевіряємо наявність компонентів...");
            Console.WriteLine("   CPU          - зарезервовано");
            Console.WriteLine("   Материнська плата - зарезервовано");
            Console.WriteLine("   RAM          - зарезервовано");
            Console.WriteLine("   GPU          - зарезервовано");
            
            Console.WriteLine("Всі компоненти зарезервовані на складі");
            
            request.IsStockReserved = true;

            if (nextHandler != null)
            {
                nextHandler.Handle(request);
            }
        }
    }
}

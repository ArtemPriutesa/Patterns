using System;
using System.Threading;

namespace Patterns.Behavioral.ChainOfResponsibility
{
    /// <summary>
    /// Обробник оплати замовлення
    /// </summary>
    public class PaymentHandler : OrderHandler
    {
        public override void Handle(OrderRequest request)
        {
            if (!request.IsValidated)
            {
                Console.WriteLine("[Оплата] Замовлення не валідне - пропускаємо платіж");
                return;
            }

            Console.WriteLine("[Оплата Замовлення]");
            
            Console.WriteLine($"  Обробляємо платіж: ${request.Amount}...");
            Thread.Sleep(800); 
            
            if (new Random().Next(0, 5) == 0)
            {
                Console.WriteLine("Помилка платежу: Картка відхилена");
                return;
            }

            Console.WriteLine("Платіж успішно оброблений");
            
            request.HasPayment = true;

            if (nextHandler != null)
            {
                nextHandler.Handle(request);
            }
        }
    }
}

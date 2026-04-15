using System;

namespace Patterns.Behavioral.ChainOfResponsibility
{
    public class NotificationHandler : OrderHandler
    {
        public override void Handle(OrderRequest request)
        {
            if (!request.IsReadyToShip)
            {
                Console.WriteLine("[Сповіщення] Замовлення не готове до доставки");
                return;
            }

            Console.WriteLine("[Сповіщення Клієнту]");
            
            Console.WriteLine("Надісліємо email клієнту:");
            Console.WriteLine("Тема: Ваше замовлення готове до відправки!");
            Console.WriteLine("Вміст: Ваш комп'ютер буде відправлено протягом 24 годин.");

            if (nextHandler != null)
            {
                nextHandler.Handle(request);
            }
        }
    }
}

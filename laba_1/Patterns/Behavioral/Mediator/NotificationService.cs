using System;

namespace Patterns.Behavioral.Mediator
{
    public class NotificationService
    {
        private readonly IOrderMediator _mediator;

        public NotificationService(IOrderMediator mediator)
        {
            _mediator = mediator;
        }

        public void SendOrderNotification(string orderId, string message)
        {
            Console.WriteLine($"  Сповіщення клієнту про замовлення {orderId}");
            Console.WriteLine($"     Тема: {message}");
        }

        public void SendStatusUpdate(string orderId, string status)
        {
            Console.WriteLine($"  Оновлення статусу для {orderId}: {status}");
        }
    }
}

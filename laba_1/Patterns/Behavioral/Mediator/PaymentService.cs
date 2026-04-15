using System;

namespace Patterns.Behavioral.Mediator
{
    public class PaymentService
    {
        private readonly IOrderMediator _mediator;

        public PaymentService(IOrderMediator mediator)
        {
            _mediator = mediator;
        }

        public bool ProcessPayment(string orderId, decimal amount)
        {
            Console.WriteLine($"  Обробка платежу: {orderId} на суму ${amount}");
            
            if (new Random().Next(0, 5) == 0)
            {
                Console.WriteLine($"  Платіж відхилено!");
                return false;
            }

            Console.WriteLine($"  Платіж успішно оброблений");
            return true;
        }
    }
}

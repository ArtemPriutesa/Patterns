using System;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.ChainOfResponsibility
{
    public class ValidateOrderHandler : OrderHandler
    {
        public override void Handle(OrderRequest request)
        {
            Console.WriteLine("[Валідація Замовлення]");
            
            if (request.Order == null)
            {
                Console.WriteLine(" Помилка: Замовлення нульове");
                return;
            }

            if (request.Amount <= 0)
            {
                Console.WriteLine(" Помилка: Невірна сума замовлення");
                return;
            }

            Console.WriteLine(" Замовлення валідне");
            Console.WriteLine($"  Сума: ${request.Amount}");
            
            request.IsValidated = true;

            if (nextHandler != null)
            {
                nextHandler.Handle(request);
            }
        }
    }
}

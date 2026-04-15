using System;

namespace Patterns.Behavioral.ChainOfResponsibility
{
    public class ShippingHandler : OrderHandler
    {
        public override void Handle(OrderRequest request)
        {
            if (!request.IsStockReserved)
            {
                Console.WriteLine("[Доставка] Компоненти не зарезервовані - не можемо відправити");
                return;
            }

            Console.WriteLine("[Підготовка до Доставки]");
            
            Console.WriteLine("  Комплектуємо комп'ютер...");
            Console.WriteLine("  Асемблювання завершено");
            Console.WriteLine("  Тестування пройдено");
            Console.WriteLine("  Упаковка виконана");
            
            Console.WriteLine("Замовлення готове до доставки!");
            
            request.IsReadyToShip = true;

            // Передаємо далі в ланцюг
            if (nextHandler != null)
            {
                nextHandler.Handle(request);
            }
        }
    }
}

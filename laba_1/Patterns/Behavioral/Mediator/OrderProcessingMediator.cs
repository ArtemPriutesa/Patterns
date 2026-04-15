using System;
using Patterns.Behavioral.Observer;

namespace Patterns.Behavioral.Mediator
{
    public class OrderProcessingMediator : IOrderMediator
    {
        private readonly WarehouseWithObserver _warehouse;
        private readonly PaymentService _paymentService;
        private readonly NotificationService _notificationService;
        private readonly CompatibilityChecker _compatibilityChecker;

        public OrderProcessingMediator(
            WarehouseWithObserver warehouse,
            PaymentService paymentService,
            NotificationService notificationService,
            CompatibilityChecker compatibilityChecker)
        {
            _warehouse = warehouse;
            _paymentService = paymentService;
            _notificationService = notificationService;
            _compatibilityChecker = compatibilityChecker;
        }

        public void ProcessOrder(OrderRequest request)
        {
            Console.WriteLine($"\n Медіатор отримав замовлення: {request.OrderId}\n");

            if (!_compatibilityChecker.CheckCompatibility(request.ComponentName))
            {
                Console.WriteLine(" Компонент несумісний - замовлення скасовано!\n");
                _notificationService.SendOrderNotification(request.OrderId, "Замовлення скасовано - компонент несумісний");
                return;
            }

            Console.WriteLine();

            bool stockReserved = ReserveStock(request.ComponentName, request.Quantity);
            if (!stockReserved)
            {
                Console.WriteLine(" Компоненти недоступні - замовлення скасовано!\n");
                _notificationService.SendOrderNotification(request.OrderId, "Замовлення скасовано - компоненти недоступні");
                return;
            }

            Console.WriteLine();

            bool paymentSuccessful = _paymentService.ProcessPayment(request.OrderId, request.Amount);
            if (!paymentSuccessful)
            {
                Console.WriteLine(" Платіж не пройшов - скасовуємо резервування!\n");
                
                ReleaseStock(request.ComponentName, request.Quantity);
                _notificationService.SendOrderNotification(request.OrderId, "Платіж відхилено");
                return;
            }

            Console.WriteLine();

            _notificationService.SendOrderNotification(request.OrderId, "Замовлення прийнято та повністю обробляється");
            
            Console.WriteLine(" Замовлення успішно обробляється!");
        }

        public void NotifyOrderStatusChanged(string orderId, string newStatus)
        {
            Console.WriteLine($" Медіатор: Статус замовлення {orderId} змінився на {newStatus}");
            _notificationService.SendStatusUpdate(orderId, newStatus);
        }

        public void RequestStockReservation(string componentName, int quantity)
        {
            ReserveStock(componentName, quantity);
        }

        public void RequestPayment(string orderId, decimal amount)
        {
            _paymentService.ProcessPayment(orderId, amount);
        }

        public void NotifyCompletionCommand(string orderId)
        {
            Console.WriteLine($" Медіатор: Замовлення {orderId} завершено!");
            _notificationService.SendOrderNotification(orderId, "Ваше замовлення доставлено!");
        }

        private bool ReserveStock(string componentName, int quantity)
        {
            Console.WriteLine($"  Резервування складу: {quantity} шт. '{componentName}'");
            
            if (_warehouse.GetQuantity(componentName) >= quantity)
            {
                _warehouse.ReduceStock(componentName);
                Console.WriteLine($"  Компоненти зарезервовані");
                return true;
            }

            Console.WriteLine($"  Недостатньо компонентів!");
            return false;
        }

        private void ReleaseStock(string componentName, int quantity)
        {
            Console.WriteLine($"  Скасування резервування: {quantity} шт. '{componentName}'");
            _warehouse.AddStock(componentName, quantity);
        }
    }
}

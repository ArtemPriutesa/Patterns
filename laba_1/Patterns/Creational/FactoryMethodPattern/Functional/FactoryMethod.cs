using System;
using Patterns.Model;
using Patterns.FactoryMethodPattern;

namespace Patterns.FactoryMethodPattern.Functional
{
    // 1. Сама фабрика: один простий метод замість купи класів
    public static class InvoiceFactory
    {
        public static Func<IInvoice> GetCreator(string type) => type.ToLower() switch
        {
            "corporate" => () => new CorporateInvoice(),
            "express"   => () => new CorporateInvoice(), // Тут можна передати інші параметри
            _           => () => new RetailInvoice()     // За замовчуванням
        };
    }

    // 2. Процесор: не знає про класи чи типи, знає лише про функцію
    public class OrderProcessor
    {
        private readonly Func<IInvoice> _createInvoice;

        // Ін'єктуємо функцію-фабрику
        public OrderProcessor(Func<IInvoice> createInvoice)
        {
            _createInvoice = createInvoice ?? throw new ArgumentNullException(nameof(createInvoice));
        }

        public void ProcessOrder(Computer pc)
        {
            Console.WriteLine("Обробка замовлення...");
            
            // Створюємо інвойс у потрібний момент
            var invoice = _createInvoice(); 
            invoice.Print(pc);
        }
    }
}
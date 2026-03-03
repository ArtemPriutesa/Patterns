using Patterns.Model;

namespace Patterns.FactoryMethodPattern
{
    public abstract class OrderManager
    {
        public abstract IInvoice CreateInvoice();

        public void ProcessOrder(Computer pc)
        {
            IInvoice invoice = CreateInvoice(); 
            Console.WriteLine("Обробка замовлення...");
            System.Threading.Thread.Sleep(1000);
            invoice.Print(pc);
        }
    }
}

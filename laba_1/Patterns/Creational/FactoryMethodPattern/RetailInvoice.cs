using Patterns.Model;

namespace Patterns.FactoryMethodPattern
{
    public class RetailInvoice : IInvoice
    {
        public void Print(Computer pc) => 
            Console.WriteLine($"[ФІЗ. ОСОБА] Чек: {pc}. Ціна: 1500$. Гарантія: 1 рік.");
    }
}

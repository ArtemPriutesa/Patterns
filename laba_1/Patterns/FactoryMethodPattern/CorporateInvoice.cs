using Patterns.Model;

namespace Patterns.FactoryMethodPattern
{
    public class CorporateInvoice : IInvoice
    {
        public void Print(Computer pc) => 
            Console.WriteLine($"[ЮР. ОСОБА] Рахунок-фактура: {pc}. Ціна: 1250$. Гарантія: 3 роки.");
    }
}

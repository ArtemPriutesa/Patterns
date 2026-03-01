namespace laba_1.creational.FactoryMethod
{
    public interface IInvoice
    {   
    void Print(Computer pc);
    }

    public class RetailInvoice : IInvoice
    {
        public void Print(Computer pc) => 
           Console.WriteLine($"[ФІЗ. ОСОБА] Чек: {pc}. Ціна: 1500$. Гарантія: 1 рік.");
    }   

    public class CorporateInvoice : IInvoice
    {
        public void Print(Computer pc) => 
          Console.WriteLine($"[ЮР. ОСОБА] Рахунок-фактура: {pc}. Ціна: 1250$. Гарантія: 3 роки.");
    }
}
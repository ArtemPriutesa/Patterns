using Patterns.Model;

namespace Patterns.Structural
{
    public class ServerCpuAdapter : ICPU
    {
        private OldServerProcessor oldProcessor;

        public ServerCpuAdapter(OldServerProcessor oldProcessor)
        {
            this.oldProcessor = oldProcessor;
        }

        public string GetCPU()
        {
            return $"Адаптер CPU: {oldProcessor.GetIdentifier()} : {oldProcessor.TechnicalSpecs}";
        }

        public string ModelName()
        {
            return oldProcessor.GetIdentifier();
        }

        public string GetDetails()
        {
            return GetCPU();
        }

        public string GetName()
        {
            return ModelName();
        }
        public double GetPrice()
        {
            return 499.99; 
            }
        public void DisplayDetails(int depth)
        {
            string indent = new string(' ', depth * 2);
            Console.WriteLine($"{indent}- {GetName()}: {GetDetails()} (Price: ${GetPrice()})");
        }
    }
}
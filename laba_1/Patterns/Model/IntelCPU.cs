namespace Patterns.Model
{
    public class IntelCPU : ICPU
    {
        private string model;

        public IntelCPU(string model)
        {
            this.model = model;
        }

        public string GetCPU()
        {
            return $"Intel CPU: {model}";
        }

        public string ModelName()
        {
            return model;
        }

        public string GetDetails()
        {
            return $"CPU: {model}";
        }

        public string GetName()
        {
            return "Intel CPU";
        }

        public double GetPrice()
        {
            return model switch
            {
                "Core i5-11600K" => 269.99,
                "Core i7-11700K" => 399.99,
                "Core i9-11900K" => 549.99,
                _ => 199.99 
            };
        }
        public void DisplayDetails(int depth)
        {
            string indent = new string(' ', depth * 2);
            Console.WriteLine($"{indent}- {GetName()}: {GetDetails()} (Price: ${GetPrice()})");
        }
    }
}

namespace Patterns.Model
{
    public class AMDCPU : ICPU
    {
        private string model;

        public AMDCPU(string model)
        {
            this.model = model;
        }

        public string GetCPU()
        {
            return $"AMD CPU: {model}";
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
            return "AMD CPU";
        }

        public double GetPrice()
        {
           
            return model switch
            {
                "Ryzen 5 5600X" => 299.99,
                "Ryzen 7 5800X" => 449.99,
                "Ryzen 9 5900X" => 549.99,
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

namespace Patterns.Model
{
    public class AMDMotherboard : IMotherboard
    {
        private string socketType;

        public AMDMotherboard(string socketType)
        {
            this.socketType = socketType;
        }

        public string GetSocketType()
        {
            return socketType;
        }

        public string GetMotherboard()
        {
            return $"Материнська плата AMD з сокетом: {socketType}";
        }

        public string GetDetails()
        {
            return GetMotherboard();
        }

        public string GetName()
        {
            return "AMDMotherboard";
        }

        public double GetPrice()
        {
            return 150.0;
        }

        public void DisplayDetails(int depth)
        {
            string indent = new string(' ', depth * 2);
            Console.WriteLine($"{indent}- {GetName()}: {GetDetails()} (Price: ${GetPrice()})");
        }
    }
}

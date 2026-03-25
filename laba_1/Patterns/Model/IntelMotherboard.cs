namespace Patterns.Model
{
    public class IntelMotherboard : IMotherboard
    {
        private string socketType;

        public IntelMotherboard(string socketType)
        {
            this.socketType = socketType;
        }

        public string GetSocketType()
        {
            return socketType;
        }

        public string GetMotherboard()
        {
            return $"Материнська плата Intel з сокетом: {socketType}";
        }

        public string GetDetails()
        {
            return GetMotherboard();
        }

        public string GetName()
        {
            return "IntelMotherboard";
        }

        public double GetPrice()
        {
            return 200.0;
        }

        public void DisplayDetails(int depth)
        {
            string indent = new string(' ', depth * 2);
            Console.WriteLine($"{indent}- {GetName()}: {GetDetails()} (Price: ${GetPrice()})");
        }
    }
}

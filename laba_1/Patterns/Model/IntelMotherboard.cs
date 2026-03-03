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
    }
}

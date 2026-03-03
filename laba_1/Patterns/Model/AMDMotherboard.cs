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
    }
}

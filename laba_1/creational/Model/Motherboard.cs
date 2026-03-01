namespace laba_1.creational.Model   
{
    public interface IMotherboard
    {   string GetSocketType();
        string GetMotherboard();
    }
    class IntelMotherboard : IMotherboard
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

    class AMDMotherboard : IMotherboard
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
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
            return $"Intel Motherboard with Socket: {socketType}";
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
            return $"AMD Motherboard with Socket: {socketType}";
        }
    }
}
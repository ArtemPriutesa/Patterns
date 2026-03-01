namespace laba_1.creational.Factory
{
    public interface IPeripheral
    {
        string GetInfo();
    }
    public class Maouse : IPeripheral
    {
        public string GetInfo()
        {
            return "Це миша.";
        }
    }
    public class Keyboard : IPeripheral
    {
        public string GetInfo()
        {
            return "Це клавіатура.";
        }
        
    }
    public class Monitor : IPeripheral
    {
        public string GetInfo()
        {
            return "Це монітор.";
        }
    }
    public class PeripheralFactory
    {
        public IPeripheral CreatePeripheral(string type)
        {
            switch (type.ToLower())
            {
                case "mouse":
                    return new Maouse();
                case "keyboard":
                    return new Keyboard();
                case "monitor":
                    return new Monitor();
                default:
                    throw new ArgumentException("Unknown peripheral type");
            }
        }
    }
}
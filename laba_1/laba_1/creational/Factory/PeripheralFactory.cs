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
            return "This is a mouse.";
        }
    }
    public class Keyboard : IPeripheral
    {
        public string GetInfo()
        {
            return "This is a keyboard.";
        }
        
    }
    public class Monitor : IPeripheral
    {
        public string GetInfo()
        {
            return "This is a monitor.";
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
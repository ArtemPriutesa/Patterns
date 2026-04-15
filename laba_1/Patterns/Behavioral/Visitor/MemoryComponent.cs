namespace Patterns.Behavioral.Visitor
{
    public class MemoryComponent : IComputerComponent
    {
        private readonly string _name;
        private readonly decimal _price;
        private readonly int _capacityGB;

        public MemoryComponent(string name, decimal price, int capacityGB)
        {
            _name = name;
            _price = price;
            _capacityGB = capacityGB;
        }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string GetName() => _name;
        public decimal GetBasePrice() => _price;
        public int GetCapacity() => _capacityGB;
    }
}

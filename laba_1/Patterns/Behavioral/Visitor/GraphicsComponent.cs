namespace Patterns.Behavioral.Visitor
{
    public class GraphicsComponent : IComputerComponent
    {
        private readonly string _name;
        private readonly decimal _price;

        public GraphicsComponent(string name, decimal price)
        {
            _name = name;
            _price = price;
        }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string GetName() => _name;
        public decimal GetBasePrice() => _price;
    }
}

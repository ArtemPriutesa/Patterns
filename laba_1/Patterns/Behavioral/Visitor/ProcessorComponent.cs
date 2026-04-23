namespace Patterns.Behavioral.Visitor
{
    // Конкретний компонент комп'ютера, який реалізує інтерфейс IComputerComponent та приймає відвідувача для виконання операцій над собою  
    public class ProcessorComponent : IComputerComponent
    {
        private readonly string _name;
        private readonly decimal _price;

        public ProcessorComponent(string name, decimal price)
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

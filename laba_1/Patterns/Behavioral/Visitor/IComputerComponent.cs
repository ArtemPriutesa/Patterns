namespace Patterns.Behavioral.Visitor
{
    // Інтерфейс компонента комп'ютера, який приймає відвідувача для виконання операцій над собою
    public interface IComputerComponent
    {
        void Accept(IComponentVisitor visitor);
        string GetName();
        decimal GetBasePrice();
    }
}

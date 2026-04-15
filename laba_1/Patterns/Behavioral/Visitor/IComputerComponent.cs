namespace Patterns.Behavioral.Visitor
{
    public interface IComputerComponent
    {
        void Accept(IComponentVisitor visitor);
        string GetName();
        decimal GetBasePrice();
    }
}

namespace Patterns.Behavioral.State
{
    public interface IOrderState
    {
        void Process(Order order);
        void Ship(Order order);
        void Deliver(Order order);
        void Cancel(Order order);
        string GetStatus();
    }
}

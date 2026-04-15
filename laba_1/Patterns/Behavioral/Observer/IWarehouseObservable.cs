namespace Patterns.Behavioral.Observer
{
    public interface IWarehouseObservable
    {
        void Subscribe(IWarehouseObserver observer);
        void Unsubscribe(IWarehouseObserver observer);
        void Notify(string componentName, int newQuantity);
    }
}

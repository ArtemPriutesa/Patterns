namespace Patterns.Behavioral.Observer
{
    // Інтерфейс для об'єктів, які можуть бути спостережуваними (Observable) у патерні Observer
    public interface IWarehouseObservable
    {
        void Subscribe(IWarehouseObserver observer);
        void Unsubscribe(IWarehouseObserver observer);
        void Notify(string componentName, int newQuantity);
    }
}

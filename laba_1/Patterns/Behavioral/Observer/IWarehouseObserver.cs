namespace Patterns.Behavioral.Observer
{
    public interface IWarehouseObserver
    {
        void Update(string componentName, int newQuantity);
    }
}

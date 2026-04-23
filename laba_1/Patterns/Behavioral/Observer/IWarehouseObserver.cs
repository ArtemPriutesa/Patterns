namespace Patterns.Behavioral.Observer
{
    // Інтерфейс для спостерігачів (Observers) у патерні Observer, які отримують оновлення про зміни на складі
    public interface IWarehouseObserver
    {
        void Update(string componentName, int newQuantity);
    }
}

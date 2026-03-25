namespace Patterns.Model
{
    public interface IWarehouse
    {
        bool IsAvailable(string partName);
        void ReduceStock(string partName);
    }
}
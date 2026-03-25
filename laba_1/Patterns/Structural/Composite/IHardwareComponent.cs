namespace Patterns.Model
{
    public interface IHardwareComponent
    {
        string GetDetails();
        string GetName();
        double GetPrice();
        void DisplayDetails(int depth);
    }
}
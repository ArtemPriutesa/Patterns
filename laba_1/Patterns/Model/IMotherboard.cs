namespace Patterns.Model
{
    public interface IMotherboard : IHardwareComponent
    {
        string GetSocketType();
        string GetMotherboard();
    }
}

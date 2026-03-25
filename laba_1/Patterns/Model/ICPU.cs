using Patterns.Structural;
namespace Patterns.Model
{
    public interface ICPU : IHardwareComponent
    {
        string GetCPU();
        string ModelName();
    }
}

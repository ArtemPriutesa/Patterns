using Patterns.Model;

namespace Patterns.AbstractFactoryPattern
{
    public interface IPcFactory
    {
        ICPU CreateCpu(string cpuModel);
        IMotherboard CreateMotherboard(string socketType);
    }
}

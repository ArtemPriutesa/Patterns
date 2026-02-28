using laba_1.creational.Model;

namespace laba_1.creational.Factory
{
    public interface IPcFactory
    {
        ICPU CreateCpu(string cpuModel);
        IMotherboard CreateMotherboard(string socketType);
    }
}
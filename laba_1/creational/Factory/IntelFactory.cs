using laba_1.creational.Model;

namespace laba_1.creational.Factory
{
    class IntelFactory : IPcFactory
    {
        public ICPU CreateCpu(string cpuModel)
        {
            return new IntelCPU(cpuModel);
        }

        public IMotherboard CreateMotherboard(string socketType)
        {
            return new IntelMotherboard(socketType);
        }
    }
}
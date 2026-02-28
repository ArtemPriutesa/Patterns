using laba_1.creational.Model;

namespace laba_1.creational.Factory
{
    class AmdFactory : IPcFactory
    {
        public ICPU CreateCpu(string cpuModel)
        {
            return new AMDCPU(cpuModel);
        }

        public IMotherboard CreateMotherboard(string socketType)
        {
            return new AMDMotherboard(socketType);
        }
    }
}

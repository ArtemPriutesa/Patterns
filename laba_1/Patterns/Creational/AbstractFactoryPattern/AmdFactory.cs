using Patterns.Model;

namespace Patterns.AbstractFactoryPattern
{
    public class AmdFactory : IPcFactory
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

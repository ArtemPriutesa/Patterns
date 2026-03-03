using Patterns.Model;

namespace Patterns.AbstractFactoryPattern
{
    public class IntelFactory : IPcFactory
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

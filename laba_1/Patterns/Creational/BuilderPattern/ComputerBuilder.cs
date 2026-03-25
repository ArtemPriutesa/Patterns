using Patterns.Model;

namespace Patterns.BuilderPattern
{
    public class ComputerBuilder
    {
        private readonly AbstractFactoryPattern.IPcFactory _pcFactory;
        private ICPU? _cpu;
        private IMotherboard? _motherboard;
        private string _ram = "";
        private string _gpu = "";

        public ComputerBuilder(AbstractFactoryPattern.IPcFactory factory)
        {
            _pcFactory = factory;
        }

        public ComputerBuilder BuildCPU(string cpuModel)
        {
            _cpu = _pcFactory.CreateCpu(cpuModel);
            return this;
        }

        public ComputerBuilder BuildMotherboard(string socketType)
        {
            _motherboard = _pcFactory.CreateMotherboard(socketType);
            return this;
        }

        public ComputerBuilder BuildRAM(string ram)
        {
            _ram = ram;
            return this;
        }

        public ComputerBuilder BuildGPU(string gpu)
        {
            _gpu = gpu;
            return this;
        }

        public Computer GetComputer()
        {
            if (_cpu == null || _motherboard == null)
            {
                throw new InvalidOperationException("CPU and Motherboard must be set");
            }
            return new Computer(_cpu, _motherboard, _ram, _gpu);
        }
    }
}

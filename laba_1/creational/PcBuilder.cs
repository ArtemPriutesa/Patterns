using laba_1.creational.Factory;
using laba_1.creational.Model;

namespace laba_1.creational
{
    public class ComputerBuilder
    {
        private readonly IPcFactory _pcFactory;
        private Computer _computer;
        public ComputerBuilder(IPcFactory factory)
        {
            _pcFactory = factory;
            _computer = new Computer();
        }
        public ComputerBuilder BuildCPU(string cpuModel)
        {
            _computer.CPU = _pcFactory.CreateCpu(cpuModel);
            return this;
        }
        public ComputerBuilder BuildMotherboard(string socketType)
        {
            _computer.Motherboard = _pcFactory.CreateMotherboard(socketType);
            return this;
        }
        public ComputerBuilder BuildRAM(int ram)
        {
            _computer.RAM = ram;
            return this;
        }
        public ComputerBuilder BuildGPU(string gpu)
        {
            _computer.GPU = gpu;
            return this;
        }
        public Computer GetComputer()
        {
            Computer finishedPc = _computer;
            
            _computer = new Computer();
            
            return finishedPc;
        }
    }
}
using laba_1.creational.Model;
using laba_1.creational.Factory;
using System.Globalization;

namespace laba_1.creational.Model

{
    public class Computer
    {
        public ICPU CPU { get; set; }
        public IMotherboard Motherboard { get; set; }
        public string RAM { get; set; }
        public string GPU { get; set; }
        public Computer(ICPU cpu, IMotherboard motherboard, string ram, string gpu)
        {
            CPU = cpu;
            Motherboard = motherboard;
            RAM = ram;
            GPU = gpu;
        }

        public Computer()
        {
        }

        public override string ToString()
        {
            return $"Computer [CPU: {CPU}, RAM: {RAM}, Motherboard: {Motherboard}, GPU: {GPU}]";
        }
        public Computer Clone()
        {
            return new Computer(CPU, Motherboard, RAM, GPU);
        }
    }
}
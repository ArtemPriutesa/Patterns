namespace Patterns.Model
{
    public class Computer
    {
        public ICPU? CPU { get; set; }
        public IMotherboard? Motherboard { get; set; }
        public string RAM { get; set; } = "";
        public string GPU { get; set; } = "";

        public Computer(ICPU cpu, IMotherboard motherboard, string ram, string gpu)
        {
            CPU = cpu;
            Motherboard = motherboard;
            RAM = ram;
            GPU = gpu;
        }

        public virtual void RunSystem()
        {
            Console.WriteLine("Running computer system.");
        }

        public override string ToString()
        {
            return $"System: {this.GetType().Name} [CPU: {CPU?.ModelName()}, RAM: {RAM}, GPU: {GPU}]";
        }

        public virtual Computer Clone()
        {
            return new Computer(CPU!, Motherboard!, RAM, GPU);
        }
    }
}

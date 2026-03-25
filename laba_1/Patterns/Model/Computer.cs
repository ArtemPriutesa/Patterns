namespace Patterns.Model
{
    public abstract class Computer
    {
        public ICPU? CPU { get; set; }
        public IMotherboard? Motherboard { get; set; }
        public string RAM { get; set; } = "";
        public string GPU { get; set; } = "";

        protected Computer(ICPU cpu, IMotherboard motherboard, string ram, string gpu)
        {
            CPU = cpu;
            Motherboard = motherboard;
            RAM = ram;
            GPU = gpu;
        }

        public abstract void RunSystem();

        public override string ToString()
        {
            return $"System: {this.GetType().Name} [CPU: {CPU?.ModelName()}, RAM: {RAM}, GPU: {GPU}]";
        }

        public abstract Computer Clone();
    }
}

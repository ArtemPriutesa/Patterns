using Patterns.Model;

namespace Patterns.Structural
{
    public class OverclockedCpu : CpuDecorator
    {
        public OverclockedCpu(ICPU cpu) : base(cpu)
        {
        }

        public override string GetCPU()
        {
            return $"{_cpu.GetCPU()} (Overclocked)";
        }

        public override string GetDetails()
        {
            return $"{_cpu.GetDetails()} - This CPU is overclockedу.";
        }

        public override double GetPrice()
        {
            return _cpu.GetPrice() + 50; 
        }

        public override void DisplayDetails(int depth)
        {
            string indent = new string(' ', depth * 2);
            Console.WriteLine($"{indent}- {GetName()}: {GetDetails()} (Price: ${GetPrice()})");
        }
    }
}
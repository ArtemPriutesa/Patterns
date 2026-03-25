using Patterns.Model;

namespace Patterns.Structural
{
    public class DiagnosticFacade
    {
        private readonly ICPU _cpu;
        private readonly IMotherboard _motherboard;

        public DiagnosticFacade(ICPU cpu, IMotherboard motherboard)
        {
            _cpu = cpu;
            _motherboard = motherboard;
        }

        public void RunDiagnostics()
        {
            Console.WriteLine("Running diagnostics...");
            Console.WriteLine($"CPU: {_cpu.GetCPU()} - Model: {_cpu.ModelName()}");
            Console.WriteLine($"Motherboard: {_motherboard.GetMotherboard()} - Socket: {_motherboard.GetSocketType()}");
            Console.WriteLine("Diagnostics completed successfully.");
        }
    }

}
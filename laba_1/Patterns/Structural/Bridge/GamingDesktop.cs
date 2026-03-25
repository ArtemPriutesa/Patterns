using Patterns.Model;

namespace Patterns.Structural
{
    public class GamingDesktop : Computer
    {
        public GamingDesktop(ICPU cpu, IMotherboard motherboard, string ram, string gpu)
            : base(cpu, motherboard, ram, gpu)
        {
        }

        public override void RunSystem()
        {
            Console.WriteLine($"Running gaming desktop with {CPU?.ModelName()} and GPU: {GPU}");
        }

        public override Computer Clone()
        {
            return new GamingDesktop(CPU!, Motherboard!, RAM, GPU);
        }
    }


}
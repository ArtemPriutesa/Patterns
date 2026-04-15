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
            Console.WriteLine($"Запуск ігрового компьютера с {CPU?.ModelName()} и GPU: {GPU}");
        }

        public override Computer Clone()
        {
            return new GamingDesktop(CPU!, Motherboard!, RAM, GPU);
        }
    }


}
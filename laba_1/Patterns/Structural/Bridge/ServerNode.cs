namespace Patterns.Model
{
    public class ServerNode : Computer
    {
        public ServerNode(ICPU cpu, IMotherboard motherboard, string ram, string gpu)
            : base(cpu, motherboard, ram, gpu)
        {
        }

        public override void RunSystem()
        {
            Console.WriteLine($"Запуск серверного вузла з {CPU?.ModelName()} и RAM: {RAM}");
        }

        public override Computer Clone()
        {
            return new ServerNode(CPU!, Motherboard!, RAM, GPU);
        }
    }
}
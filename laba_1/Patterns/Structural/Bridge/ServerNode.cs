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
            Console.WriteLine("Server node is running with high performance and reliability.");
        }

        public override Computer Clone()
        {
            return new ServerNode(CPU!, Motherboard!, RAM, GPU);
        }
    }
}
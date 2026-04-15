namespace Patterns.Behavioral.Visitor
{
    public interface IComponentVisitor
    {
        void Visit(ProcessorComponent processor);
        void Visit(MotherboardComponent motherboard);
        void Visit(GraphicsComponent graphics);
        void Visit(MemoryComponent memory);
    }
}

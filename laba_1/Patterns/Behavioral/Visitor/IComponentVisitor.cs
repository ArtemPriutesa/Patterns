namespace Patterns.Behavioral.Visitor
{
    // Інтерфейс відвідувача, який визначає методи для відвідування різних типів компонентів комп'ютера
    public interface IComponentVisitor
    {
        void Visit(ProcessorComponent processor);
        void Visit(MotherboardComponent motherboard);
        void Visit(GraphicsComponent graphics);
        void Visit(MemoryComponent memory);
    }
}

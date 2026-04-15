using System;
using System.Collections.Generic;

namespace Patterns.Behavioral.Visitor
{
    public class SpecificationVisitor : IComponentVisitor
    {
        private readonly List<string> _specifications = new();

        public void Visit(ProcessorComponent processor)
        {
            _specifications.Add($"Процесор: {processor.GetName()}");
        }

        public void Visit(MotherboardComponent motherboard)
        {
            _specifications.Add($"Материнська плата: {motherboard.GetName()}");
        }

        public void Visit(GraphicsComponent graphics)
        {
            _specifications.Add($"Відеокарта: {graphics.GetName()}");
        }

        public void Visit(MemoryComponent memory)
        {
                
            _specifications.Add($"Оперативна пам'ять: {memory.GetName()} ({memory.GetCapacity()}GB)");
        }

        public void DisplaySpecifications()
        {
            Console.WriteLine("\nСпецифікація системи:");
            foreach (var spec in _specifications)
            {
                Console.WriteLine($"  • {spec}");
            }
        }
    }
}

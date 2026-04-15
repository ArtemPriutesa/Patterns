using System;

namespace Patterns.Behavioral.Visitor
{
    public class PriceCalculatorVisitor : IComponentVisitor
    {
        public decimal TotalPrice { get; private set; }

        public void Visit(ProcessorComponent processor)
        {
            Console.WriteLine($" CPU: {processor.GetName()} = ${processor.GetBasePrice()}");
            TotalPrice += processor.GetBasePrice();
        }

        public void Visit(MotherboardComponent motherboard)
        {
            Console.WriteLine($"  Материнська плата: {motherboard.GetName()} = ${motherboard.GetBasePrice()}");
            TotalPrice += motherboard.GetBasePrice();
        }

        public void Visit(GraphicsComponent graphics)
        {
            Console.WriteLine($" Графічна карта: {graphics.GetName()} = ${graphics.GetBasePrice()}");
            TotalPrice += graphics.GetBasePrice();
        }

        public void Visit(MemoryComponent memory)
        {
            Console.WriteLine($" Пам'ять: {memory.GetName()} ({memory.GetCapacity()}GB) = ${memory.GetBasePrice()}");
            TotalPrice += memory.GetBasePrice();
        }

        public void DisplayTotal()
        {
            Console.WriteLine($"\n Загальна вартість: ${TotalPrice}");
        }
    }
}

using System;
using System.Diagnostics;
using Patterns.Model;

namespace Patterns.Structural.Functional
{
    public static class CpuDecorators
    {
        private static string Ident(int d) => new string(' ', d * 2);

        // Базове виведення інформації
        public static Action<ICPU, int> DisplayBase() => (cpu, depth) =>
            Console.WriteLine($"{Ident(depth)}{cpu.GetName()}: {cpu.GetDetails()} - ${cpu.GetPrice()}");

        // Декоратор модифікації (додає логіку ПІСЛЯ)
        public static Action<ICPU, int> WithDetails(this Action<ICPU, int> action, string text) => (cpu, depth) =>
        {
            action(cpu, depth);
            Console.WriteLine($"{Ident(depth)}  {text}");
        };

        // Декоратор типу Execute Around (огортає дію ДО та ПІСЛЯ)
        public static Action<ICPU, int> WithMetrics(this Action<ICPU, int> action, string name = "Дія") => (cpu, depth) =>
        {
            var sw = Stopwatch.StartNew();
            Console.WriteLine($"{Ident(depth)}[START] {name}");
            try
            {
                action(cpu, depth);
            }
            finally
            {
                Console.WriteLine($"{Ident(depth)}[END] {name} ({sw.ElapsedMilliseconds}ms)\n");
            }
        };
    }
}
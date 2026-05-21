using System;
using System.Diagnostics;
using Patterns.Model;

namespace Patterns.Structural.Functional
{
    // Визначаємо сигнатуру дії
    public delegate void CpuAction(ICPU cpu, int depth = 0);

    public static class CpuDecorators
    {
        private static string GetIndent(int depth) => new string(' ', depth * 2);

        // 1. Базова дія
        public static CpuAction DisplayBase() => (cpu, depth) =>
            Console.WriteLine($"{GetIndent(depth)}{cpu.GetName()}: {cpu.GetDetails()} - ${cpu.GetPrice()}");

        // 2. Декоратор: Знижка (Метод розширення)
        public static CpuAction WithDiscount(this CpuAction action, double percent) => (cpu, depth) =>
        {
            action(cpu, depth);
            Console.WriteLine($"{GetIndent(depth)}  💰 Знижка: -{percent}%");
        };

        // 3. Декоратор: RGB підсвітка
        public static CpuAction WithRGB(this CpuAction action, double cost = 30) => (cpu, depth) =>
        {
            action(cpu, depth);
            Console.WriteLine($"{GetIndent(depth)}  🌈 RGB: +${cost}");
        };

        // 4. Execute Around: Метрики (час виконання)
        public static CpuAction WithMetrics(this CpuAction action) => (cpu, depth) =>
        {
            var sw = Stopwatch.StartNew();
            Console.WriteLine($"{GetIndent(depth)}📊 [START]");
            
            action(cpu, depth);
            
            sw.Stop();
            Console.WriteLine($"{GetIndent(depth)}📊 [END] Time: {sw.ElapsedMilliseconds}ms\n");
        };
    }
}
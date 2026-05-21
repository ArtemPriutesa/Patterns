using Patterns.Model;
using System;
using System.Diagnostics;

namespace Patterns.Structural.Functional
{
    public delegate void CpuOperation(ICPU cpu, int depth = 0);
    public static class CpuExecuteAroundPatterns
    {
        public static CpuOperation ExecuteAround(
            CpuOperation baseOperation,
            Action<string> beforeAction,
            Action<string> afterAction,
            string message = "Операція") =>
            (cpu, depth) =>
            {
                beforeAction(message);      // ДО
                baseOperation(cpu, depth);  // ВИКОНАННЯ
                afterAction(message);       // ПІСЛЯ
            };
        public static CpuOperation ExecuteAroundWithErrorHandling(
            CpuOperation baseOperation,
            Action<string> beforeAction,
            Action<string> afterAction,
            Action<string, Exception> errorAction,
            string message = "Операція") =>
            (cpu, depth) =>
            {
                try
                {
                    beforeAction(message);
                    baseOperation(cpu, depth);
                }
                catch (Exception ex)
                {
                    errorAction(message, ex);
                }
                finally
                {
                    afterAction(message);
                }
            };
        public static CpuOperation ExecuteAroundWithMetrics(
            CpuOperation baseOperation,
            string operationName = "CPU Operation") =>
            (cpu, depth) =>
            {
                var sw = Stopwatch.StartNew();
                string indent = new string(' ', depth * 2);

                Console.WriteLine($"{indent}📊 [METRICS] Початок: {operationName}");
                var startMemory = GC.GetTotalMemory(false);

                try
                {
                    baseOperation(cpu, depth);
                }
                finally
                {
                    sw.Stop();
                    var endMemory = GC.GetTotalMemory(false);
                    var memoryDelta = endMemory - startMemory;

                    Console.WriteLine($"{indent}📊 [METRICS] Час: {sw.ElapsedMilliseconds}ms | Пам'ять: {memoryDelta / 1024}KB\n");
                }
            };
        public static CpuOperation ExecuteAroundWithLogging(
            CpuOperation baseOperation,
            Action<string> logAction,
            string prefix = "[LOG]") =>
            (cpu, depth) =>
            {
                logAction($"{prefix} START - {cpu.GetName()}");
                try
                {
                    baseOperation(cpu, depth);
                }
                finally
                {
                    logAction($"{prefix} END - {cpu.GetName()}\n");
                }
            };
    }
    public class CpuExecuteAroundOperation
    {
        private CpuOperation _operation;

        public CpuExecuteAroundOperation(CpuOperation baseOperation)
        {
            _operation = baseOperation ?? throw new ArgumentNullException(nameof(baseOperation));
        }

        public void AddExecuteAround(
            Action<string> beforeAction,
            Action<string> afterAction,
            string message = "Операція")
        {
            _operation = CpuExecuteAroundPatterns.ExecuteAround(
                _operation, beforeAction, afterAction, message);
        }
        public void AddErrorHandling(
            Action<string> beforeAction,
            Action<string> afterAction,
            Action<string, Exception> errorAction,
            string message = "Операція")
        {
            _operation = CpuExecuteAroundPatterns.ExecuteAroundWithErrorHandling(
                _operation, beforeAction, afterAction, errorAction, message);
        }
        public void AddMetrics(string operationName = "CPU Operation")
        {
            _operation = CpuExecuteAroundPatterns.ExecuteAroundWithMetrics(
                _operation, operationName);
        }
        public void AddLogging(
            Action<string> logAction,
            string prefix = "[LOG]")
        {
            _operation = CpuExecuteAroundPatterns.ExecuteAroundWithLogging(
                _operation, logAction, prefix);
        }

        public void Execute(ICPU cpu, int depth = 0)
        {
            _operation(cpu, depth);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Patterns.Behavioral.Observer
{
    // Спостерігач для збору аналітики про зміни запасів на складі
    public class AnalyticsObserver : IWarehouseObserver
    {
        private readonly Dictionary<string, int> _changeHistory = new();

        public void Update(string componentName, int newQuantity)
        {
            if (!_changeHistory.ContainsKey(componentName))
            {
                _changeHistory[componentName] = 0;
            }
            _changeHistory[componentName]++;
            
            Console.WriteLine($"Аналітика: '{componentName}' змінювався {_changeHistory[componentName]} разів. Поточна кількість: {newQuantity}");
        }

        public void PrintReport()
        {
            Console.WriteLine("\n=== ЗВІТ АНАЛІТИКИ СКЛАДУ ===");
            foreach (var item in _changeHistory)
            {
                Console.WriteLine($"  {item.Key}: {item.Value} змін");
            }
        }
    }
}

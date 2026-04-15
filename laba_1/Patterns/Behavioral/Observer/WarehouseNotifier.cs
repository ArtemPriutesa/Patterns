using System;
using System.Collections.Generic;

namespace Patterns.Behavioral.Observer
{
    public class WarehouseNotifier : IWarehouseObserver
    {
        private readonly string _name;

        public WarehouseNotifier(string name)
        {
            _name = name;
        }

        public void Update(string componentName, int newQuantity)
        {
            Console.WriteLine($"[{_name}] Сповіщення: компонент '{componentName}' тепер має {newQuantity} одиниць на складі");
        }
    }
}

using System;
using System.Collections.Generic;
using Patterns.Model;

namespace Patterns.Behavioral.Observer
{
    public class WarehouseWithObserver : IWarehouseObservable
    {
        private static WarehouseWithObserver? _instance;
        private readonly Dictionary<string, int> _inventory = new();
        private readonly List<IWarehouseObserver> _observers = new();

        private WarehouseWithObserver()
        {
            InitializeInventory();
        }

        public static WarehouseWithObserver Instance
        {
            get
            {
                _instance ??= new WarehouseWithObserver();
                return _instance;
            }
        }

        private void InitializeInventory()
        {
            _inventory["i9-14900K"] = 10;
            _inventory["Ryzen 9 7950X"] = 8;
            _inventory["LGA1700"] = 15;
            _inventory["AM5"] = 12;
            _inventory["RTX 4080"] = 5;
            _inventory["RTX 3070"] = 3;
            _inventory["32GB DDR5"] = 20;
            _inventory["64GB DDR4"] = 7;
        }

        public void Subscribe(IWarehouseObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                Console.WriteLine($"Спостерігач підписався на оновлення складу");
            }
        }

        public void Unsubscribe(IWarehouseObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"Спостерігач відписався від оновлень складу");
        }

        public void Notify(string componentName, int newQuantity)
        {
            foreach (var observer in _observers)
            {
                observer.Update(componentName, newQuantity);
            }
        }

        public void ReduceStock(string componentName)
        {
            if (_inventory.ContainsKey(componentName))
            {
                _inventory[componentName]--;
                Console.WriteLine($"Видано: '{componentName}' | Залишилось: {_inventory[componentName]}");
                Notify(componentName, _inventory[componentName]); 
            }
            else
            {
                Console.WriteLine($"Компонент '{componentName}' не знайдений на складі");
            }
        }

        public void AddStock(string componentName, int quantity)
        {
            if (_inventory.ContainsKey(componentName))
            {
                _inventory[componentName] += quantity;
                Console.WriteLine($"Поповнено: '{componentName}' на {quantity} одиниць | Всього: {_inventory[componentName]}");
                Notify(componentName, _inventory[componentName]);
            }
            else
            {
                _inventory[componentName] = quantity;
                Console.WriteLine($"Додано новий компонент: '{componentName}' | Кількість: {quantity}");
                Notify(componentName, quantity);
            }
        }

        public bool IsAvailable(string componentName)
        {
            return _inventory.ContainsKey(componentName) && _inventory[componentName] > 0;
        }

        public int GetQuantity(string componentName)
        {
            return _inventory.ContainsKey(componentName) ? _inventory[componentName] : 0;
        }

        public void DisplayInventory()
        {
            Console.WriteLine("\n=== ПОТОЧНИЙ СКЛАД ===");
            foreach (var item in _inventory)
            {
                Console.WriteLine($"  {item.Key}: {item.Value} шт.");
            }
        }
    }
}

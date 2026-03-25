using System;
using System.Collections.Generic;
using System.Linq;
using Patterns.Model;

namespace Patterns.Structural
{
    public class HardwareGroup : IHardwareComponent
    {
        private readonly List<IHardwareComponent> _components = new List<IHardwareComponent>();
        private readonly string _name;

        public HardwareGroup(string name)
        {
            _name = name;
        }

        public void AddComponent(IHardwareComponent component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(IHardwareComponent component)
        {
            _components.Remove(component);
        }

        public string GetDetails()
        {
            return $"{_name} (Group)";
        }

        public string GetName()
        {
            return _name;
        }

        public double GetPrice()
        {
            return _components.Sum(c => c.GetPrice());
        }

        public void DisplayDetails(int depth)
        {
            Console.WriteLine(new string('-', depth * 2) + GetDetails());
            foreach (var component in _components)
            {
                component.DisplayDetails(depth + 1);
            }
        }
    }
}
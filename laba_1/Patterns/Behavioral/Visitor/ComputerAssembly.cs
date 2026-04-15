using System;
using System.Collections.Generic;

namespace Patterns.Behavioral.Visitor
{
    public class ComputerAssembly
    {
        private readonly List<IComputerComponent> _components = new();
        private readonly string _name;

        public ComputerAssembly(string name)
        {
            _name = name;
        }

        public void AddComponent(IComputerComponent component)
        {
            _components.Add(component);
        }

        public void Accept(IComponentVisitor visitor)
        {
            foreach (var component in _components)
            {
                component.Accept(visitor);
            }
        }

        public string GetName() => _name;
        public int GetComponentCount() => _components.Count;
    }
}

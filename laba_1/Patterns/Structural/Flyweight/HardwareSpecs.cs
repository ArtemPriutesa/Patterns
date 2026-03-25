using Patterns.Model;
using Patterns.SingletonPattern;

namespace Patterns.Structural
{
    public class HardwareSpecs
    {
        public string Name { get; }
        public string Brand { get; }
        public string Category { get; }

        public HardwareSpecs(string name, string brand, string category)
        {
            Name = name;
            Brand = brand;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Brand} {Name} ({Category})";
        }
    }
}
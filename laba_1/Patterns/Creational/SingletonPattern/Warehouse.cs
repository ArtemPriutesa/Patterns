using Patterns.Model;
using Patterns.Structural;
namespace Patterns.SingletonPattern
{

    public class Warehouse : IWarehouse
    {
       private Dictionary<HardwareSpecs, int> _stock = new Dictionary<HardwareSpecs, int>();
        
        private Dictionary<string, HardwareSpecs> _specsCache = new Dictionary<string, HardwareSpecs>();

        private static readonly Lazy<Warehouse> _instance = 
            new Lazy<Warehouse>(() => new Warehouse());

        public static Warehouse Instance => _instance.Value;

        private Warehouse()
        {
            AddInitialStock("i9-14900K", "Intel", "CPU", 5);
            AddInitialStock("RTX 4090", "NVIDIA", "GPU", 2);
            AddInitialStock("Z790", "ASUS", "Motherboard", 5);
            AddInitialStock("Mouse", "Logitech", "Periphery", 10);
        }

        private HardwareSpecs GetOrCreateSpecs(string name, string brand, string category)
        {
            if (!_specsCache.ContainsKey(name))
            {
                _specsCache[name] = new HardwareSpecs(name, brand, category);
            }
            return _specsCache[name];
        }

        private void AddInitialStock(string name, string brand, string category, int count)
        {
            var specs = GetOrCreateSpecs(name, brand, category);
            _stock[specs] = count;
        }

        public bool IsAvailable(string partName)
        {
            foreach (var specs in _stock.Keys)
            {
                if (specs.Name == partName && _stock[specs] > 0) return true;
            }
            return false;
        }

        public void ReduceStock(string partName)
        {
            HardwareSpecs? targetSpecs = null;
            foreach (var specs in _stock.Keys)
            {
                if (specs.Name == partName)
                {
                    targetSpecs = specs;
                    break;
                }
            }

            if (targetSpecs != null && _stock[targetSpecs] > 0)
            {
                _stock[targetSpecs]--;
                Console.WriteLine($"[Склад] Видано: {targetSpecs}. Залишилось: {_stock[targetSpecs]}");
            }
            else
            {
                Console.WriteLine($"[Склад] Товар {partName} відсутній!");
            }
    }
    }
}
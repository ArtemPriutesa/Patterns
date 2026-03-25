namespace Patterns.SingletonPattern
{
    public class Warehouse
    {
        private Dictionary<string, int> _stock = new Dictionary<string, int>();
        
        private static readonly Lazy<Warehouse> _instance = 
            new Lazy<Warehouse>(() => new Warehouse());

        public static Warehouse Instance => _instance.Value;

        private Warehouse()
        {
            _stock.Add("i9-14900K", 5);
            _stock.Add("Z790", 5);
            _stock.Add("32GB DDR5", 10);
            _stock.Add("RTX 4090", 2);
            _stock.Add("Mouse", 10);
            _stock.Add("Keyboard", 10);
            _stock.Add("Monitor", 5);
        }
        //Метод для перевірки наявності запчастини на складі
        public bool IsAvailable(string partName)
        {
            return _stock.ContainsKey(partName) && _stock[partName] > 0;
        }
        //Метод для зменшення кількості запчастини на складі
        public void ReduceStock(string partName)
        {
            if (IsAvailable(partName))
            {
                _stock[partName]--;
                Console.WriteLine($"[Склад] Кількість {partName} зменшена. Залишилось: {_stock[partName]}");
            }
        }
    }
}

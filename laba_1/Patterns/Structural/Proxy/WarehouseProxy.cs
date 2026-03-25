using Patterns.Model;
using Patterns.SingletonPattern;
namespace Patterns.Structural
{
    using Patterns.SingletonPattern;

    public class WarehouseProxy : IWarehouse
    {
        private readonly string _userRole;
        
        private readonly IWarehouse _realWarehouse = Warehouse.Instance;

        public WarehouseProxy(string userRole)
        {
            _userRole = userRole;
        }

        public bool IsAvailable(string partName)
        {
            return _realWarehouse.IsAvailable(partName);
        }

        public void ReduceStock(string partName)
        {
            if (_userRole == "Admin")
            {
                Console.WriteLine($"[Proxy] Доступ дозволено для ролі: {_userRole}");
                _realWarehouse.ReduceStock(partName);
            }
            else
            {
                Console.WriteLine($"[Proxy] ВІДМОВА! Користувач '{_userRole}' не має прав на видачу товару.");
            }
        }
    }
}
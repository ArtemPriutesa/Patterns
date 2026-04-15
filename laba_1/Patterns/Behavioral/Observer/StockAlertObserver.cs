using System;

namespace Patterns.Behavioral.Observer
{
    public class StockAlertObserver : IWarehouseObserver
    {
        private readonly int _minimumThreshold;

        public StockAlertObserver(int minimumThreshold = 5)
        {
            _minimumThreshold = minimumThreshold;
        }

        public void Update(string componentName, int newQuantity)
        {
            if (newQuantity <= _minimumThreshold)
            {
                Console.WriteLine($" КРИТИЧНО: Запас '{componentName}' низький! Залишилось: {newQuantity} одиниць (поріг: {_minimumThreshold}");
            }
            else if (newQuantity == _minimumThreshold + 1)
            {
                Console.WriteLine($"ПОПЕРЕДЖЕННЯ: Запас '{componentName}' відновлено до {newQuantity} одиниць");
            }
        }
    }
}

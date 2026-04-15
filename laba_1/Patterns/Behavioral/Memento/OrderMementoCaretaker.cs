using System;
using System.Collections.Generic;
using Patterns.Behavioral.State;

namespace Patterns.Behavioral.Memento
{
    public class OrderMementoCaretaker
    {
        private readonly List<OrderMemento> _mementos = new();
        private int _currentCheckpoint = -1;

        public void SaveCheckpoint(OrderMemento memento)
        {
            if (_currentCheckpoint >= 0 && _currentCheckpoint < _mementos.Count - 1)
            {
                _mementos.RemoveRange(_currentCheckpoint + 1, _mementos.Count - _currentCheckpoint - 1);
            }

            _mementos.Add(memento);
            _currentCheckpoint = _mementos.Count - 1;

            Console.WriteLine($"Контрольна точка збережена: {memento.StateType}");
        }

        public OrderMemento? GoToPreviousCheckpoint()
        {
            if (_currentCheckpoint > 0)
            {
                _currentCheckpoint--;
                Console.WriteLine($"Повернення до попередньої контрольної точки");
                return _mementos[_currentCheckpoint];
            }

            Console.WriteLine("Немає попередніх контрольних точок");
            return null;
        }

        public OrderMemento? GoToNextCheckpoint()
        {
            if (_currentCheckpoint < _mementos.Count - 1)
            {
                _currentCheckpoint++;
                Console.WriteLine($"Переміщення на наступну контрольну точку");
                return _mementos[_currentCheckpoint];
            }

            Console.WriteLine("Немає наступних контрольних точок");
            return null;
        }

        public OrderMemento? GetCheckpoint(int index)
        {
            if (index >= 0 && index < _mementos.Count)
            {
                _currentCheckpoint = index;
                return _mementos[index];
            }
            return null;
        }

        public void DisplayCheckpointHistory()
        {
            Console.WriteLine("\nІсторія контрольних точок замовлення:");
            
            if (_mementos.Count == 0)
            {
                Console.WriteLine("  (порусто)");
                return;
            }

            for (int i = 0; i < _mementos.Count; i++)
            {
                string marker = i == _currentCheckpoint ? "  " : "   ";
                Console.Write(marker);
                _mementos[i].DisplayMemento();
            }
        }

        public int GetCheckpointCount() => _mementos.Count;
        public int GetCurrentCheckpointIndex() => _currentCheckpoint;
    }
}

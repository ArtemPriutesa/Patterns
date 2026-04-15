using System;

namespace Patterns.Behavioral.Mediator
{
    public class CompatibilityChecker
    {
        private readonly IOrderMediator _mediator;

        public CompatibilityChecker(IOrderMediator mediator)
        {
            _mediator = mediator;
        }

        public bool CheckCompatibility(string componentName)
        {
            Console.WriteLine($"   Перевірка сумісності для: {componentName}");

            Console.WriteLine($"  Компонент сумісний з системою");
            return true;
        }
    }
}

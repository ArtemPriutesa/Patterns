using Patterns.Behavioral.State;

namespace Patterns.Behavioral.ChainOfResponsibility
{
    // Абстрактний клас для обробників замовлення
    public abstract class OrderHandler
    {
        protected OrderHandler? nextHandler;

        public void SetNext(OrderHandler handler)
        {
            nextHandler = handler;
        }

        public abstract void Handle(OrderRequest request);
    }
}

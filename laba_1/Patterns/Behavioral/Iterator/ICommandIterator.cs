using Patterns.Behavioral.Command;

namespace Patterns.Behavioral.Iterator
{
    public interface ICommandIterator
    {
        bool HasNext();
        ICommand Next();
        bool HasPrevious();
        ICommand Previous();
        void Reset();
    }
}

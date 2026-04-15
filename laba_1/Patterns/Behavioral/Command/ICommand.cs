namespace Patterns.Behavioral.Command
{
    /// <summary>
    /// Інтерфейс команди
    /// </summary>
    public interface ICommand
    {
        void Execute();
        void Undo();
        string GetDescription();
    }
}

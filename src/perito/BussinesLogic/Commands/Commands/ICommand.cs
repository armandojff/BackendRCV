namespace perito.Commands
{
    public interface ICommand<TOut>
    {
        void Execute();
        TOut GetResult();
    }
}
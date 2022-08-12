namespace RCVUcabBackend.BussinesLogic.TallerCommands{
    public interface ICommand<TOut>
    {
        void Execute();
        TOut GetResult();
    }
}
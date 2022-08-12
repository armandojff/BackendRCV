using System.Collections.Generic;

namespace RCVUcabBackend.BussinesLogic.Commands
{
    public interface ICommand<TOut>
    {
        void Execute();
        TOut GetResult();
    }
}
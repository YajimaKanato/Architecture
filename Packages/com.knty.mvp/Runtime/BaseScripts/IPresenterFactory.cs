using System;

namespace KNTy.MVP.Runtime
{
    public interface IPresenterFactory : IDisposable
    {
        void GeneratePresenter(RuntimeModelStorage storage_RM, ViewModelStorage storage_VM, IEventHub inputHub, IEventHub eventHub);
    }
}

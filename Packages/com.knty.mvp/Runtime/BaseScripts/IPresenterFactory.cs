using System;

namespace KNTyArch.Runtime
{
    public interface IPresenterFactory : IDisposable
    {
        void GeneratePresenter(RuntimeModelStorage storage_RM, ViewModelStorage storage_VM, IEventHub inputHub, IEventHub eventHub);
    }
}

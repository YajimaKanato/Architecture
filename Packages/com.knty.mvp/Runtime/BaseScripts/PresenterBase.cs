using System;

namespace KNTy.MVP.Runtime
{
    public abstract class PresenterBase : IDisposable
    {
        protected RuntimeModelStorage _storage_RM;
        protected ViewModelStorage _storage_VM;
        protected IEventHub _inputHub;
        protected IEventHub _eventHub;
        public abstract void Initialize(RuntimeModelStorage storage_RM, ViewModelStorage storage_VM, IEventHub inputHub, IEventHub eventHub);
        protected abstract void SubscribeInputHub();
        public abstract void Dispose();
    }
}


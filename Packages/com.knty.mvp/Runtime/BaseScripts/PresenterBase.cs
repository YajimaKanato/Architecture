using System;

namespace KNTy.MVP.Runtime
{
    public abstract class PresenterBase : IDisposable
    {
        protected RuntimeModelStorage _storage_RM;
        protected ViewModelStorage _storage_VM;
        protected IEventHub _inputHub;
        protected IEventHub _eventHub;
        public PresenterBase(RuntimeModelStorage storage_RM, ViewModelStorage storage_VM, IEventHub inputHub, IEventHub eventHub)
        {
            _storage_RM = storage_RM;
            _storage_VM = storage_VM;
            _inputHub = inputHub;
            _eventHub = eventHub;
            SubscribeInputHub();
        }
        protected abstract void SubscribeInputHub();
        public abstract void Dispose();
    }
}


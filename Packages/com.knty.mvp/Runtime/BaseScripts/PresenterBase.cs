using System;

namespace KNTy.MVP.Runtime
{
    public abstract class PresenterBase : IDisposable
    {
        protected RuntimeModelStorage _storage;
        protected IEventHub _inputHub;
        protected IEventHub _eventHub;
        public PresenterBase(RuntimeModelStorage storage, IEventHub inputHub, IEventHub eventHub)
        {
            _storage = storage;
            _inputHub = inputHub;
            _eventHub = eventHub;
            SubscribeInputHub();
        }
        protected abstract void SubscribeInputHub();
        public abstract void Dispose();
    }
}


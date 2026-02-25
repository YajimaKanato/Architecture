using System;

namespace KNTy.MVP.Runtime
{
    public abstract class PresenterBase : IInitialize, IDisposable
    {
        protected IEventHub _eventHub;
        public PresenterBase(IEventHub eventHub)
        {
            _eventHub = eventHub;
        }
        public virtual string DebugLabel => GetType().Name;
        public abstract void Initialize();
        public abstract void Dispose();
    }
}


using System;

namespace KNTyArch.Runtime
{
    public abstract class PresenterBase : IDisposable
    {
        public abstract void Initialize();
        protected abstract void SubscribeInputHub();
        public abstract void Dispose();
    }
}


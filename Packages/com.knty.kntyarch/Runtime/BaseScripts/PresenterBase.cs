using System;

namespace KNTyArch.Runtime
{
    public abstract class PresenterBase : IDisposable
    {
        public abstract void Initialize();
        protected abstract void SubscribeEvent();
        public abstract void Dispose();
    }
}


using System;

namespace KNTy.MVP.Runtime
{
    public abstract class PresenterBase : IInitialize, IDisposable
    {
        public virtual string DebugLabel => GetType().Name;
        public abstract void Initialize();
        public abstract void Dispose();
    }
}


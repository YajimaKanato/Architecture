using System;

namespace KNTy.MVP.Runtime
{
    public abstract class PresenterBase : IInitialize, IDisposable
    {
        public virtual string DebugLabel => GetType().Name;
        public abstract void Initialize();
        public abstract void Dispose();
    }

    public abstract class PresenterBase<TView> : PresenterBase where TView : ViewBase
    {
        protected TView _view;
        protected abstract void Bind(TView view);
        protected abstract void Unbind();
    }
}


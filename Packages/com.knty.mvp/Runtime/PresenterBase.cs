namespace KNTy.MVP.Runtime
{
    public abstract class PresenterBase<TView> : IPresenter where TView : ViewBase
    {
        protected TView _view;

        protected PresenterBase(TView view)
        {
            _view = view;
        }

        public virtual string DebugLabel => GetType().Name;
        public virtual void Initialize() { }
        public virtual void Dispose() { }
        protected abstract void Bind();
        protected abstract void Unbind();
    }
}


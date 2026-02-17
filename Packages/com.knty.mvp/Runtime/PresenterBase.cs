namespace KNTy.MVP.Runtime
{
    public abstract class PresenterBase<TView> : IPresenter where TView : ViewBase
    {
        protected TView _view;

        public virtual string DebugLabel => GetType().Name;

        protected PresenterBase(TView view)
        {
            _view = view;
        }

        public virtual void Initialize()
        {
            _view.Initialize();
            Bind();
        }

        public virtual void Dispose()
        {
            Unbind();
        }

        protected abstract void Bind();
        protected abstract void Unbind();
    }
}


using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class InputBase : MonoBehaviour, IInitialize
    {
        [SerializeField] string _id;
        public virtual string DebugLabel => GetType().Name;
        public abstract void Initialize();
    }

    public abstract class InputBase<TPresenter> : InputBase where TPresenter : PresenterBase
    {
        protected TPresenter _presenter;
        public void SetPresenter(TPresenter presenter) => _presenter = presenter;
    }
}

using System;
using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class ViewBase : MonoBehaviour, IInitialize
    {
        public virtual string DebugLabel => GetType().Name;
        public abstract Type PresenterType { get; }
        public abstract void Initialize();
    }

    public abstract class ViewBase<TPresenter> : ViewBase where TPresenter : PresenterBase
    {
        public override Type PresenterType => typeof(TPresenter);
    }
}

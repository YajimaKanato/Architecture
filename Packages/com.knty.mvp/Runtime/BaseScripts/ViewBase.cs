using UnityEngine;
using System;

namespace KNTyArch.Runtime
{
    public abstract class ViewBase : MonoBehaviour
    {
        [SerializeField] protected ID _id;
        protected IEventHub _eventHub;
        public ID ID => _id;
        public abstract Type ModelType();
        public abstract void Initialize(ViewModelStorage storage, IEventHub eventHub);
    }

    public abstract class ViewBase<TRuntimeModel> : ViewBase where TRuntimeModel : RuntimeModelBase
    {
        public override Type ModelType() => typeof(TRuntimeModel);
    }
}

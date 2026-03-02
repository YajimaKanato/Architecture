using System;
using UnityEngine;

namespace KNTyArch.Runtime
{
    public abstract class InputBase : MonoBehaviour
    {
        [SerializeField] protected ID _id;
        protected IEventHub _inputHub;
        public ID ID => _id;
        public abstract Type ModelType();
        public void SetInputHub(IEventHub inputHub) => _inputHub = inputHub;
    }

    public abstract class InputBase<TRuntimeModel> : InputBase where TRuntimeModel : RuntimeModelBase
    {
        public override Type ModelType() => typeof(TRuntimeModel);
    }
}

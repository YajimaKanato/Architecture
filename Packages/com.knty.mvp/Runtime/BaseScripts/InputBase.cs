using System;
using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class InputBase : MonoBehaviour
    {
        [SerializeField] protected ID _id;
        protected IEventHub _inputHub;
        public ID ID => _id;
        public abstract Type RuntimeModelType();
        public void SetEventHub(IEventHub inputHub) => _inputHub = inputHub;
    }

    public abstract class InputBase<TRuntimeModel> : InputBase where TRuntimeModel : RuntimeModelBase
    {
        public override Type RuntimeModelType()
        {
            return typeof(TRuntimeModel);
        }
    }
}

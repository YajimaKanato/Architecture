using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class ModelBase : ScriptableObject
    {
        public abstract RuntimeModelBase CreateRuntimeModel();
    }

    public abstract class ModelBase<TRuntimeModel> : ModelBase where TRuntimeModel : RuntimeModelBase
    {
        public sealed override RuntimeModelBase CreateRuntimeModel()
        {
            return CreateTypedRuntimeModel();
        }

        public abstract TRuntimeModel CreateTypedRuntimeModel();
    }
}

using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class ModelBase : ScriptableObject
    {
        public abstract IRuntimeModel CreateRuntimeModel();
    }

    public abstract class ModelBase<TRuntimeModel> : ModelBase where TRuntimeModel : IRuntimeModel
    {
        public sealed override IRuntimeModel CreateRuntimeModel()
        {
            return CreateTypedRuntimeModel();
        }

        public abstract TRuntimeModel CreateTypedRuntimeModel();
    }
}

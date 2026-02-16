using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class ModelBase<T> : ScriptableObject where T : IRuntimeModel
    {
        public abstract T CreateRuntimeModel();
    }
}

using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class ViewBase : MonoBehaviour, IInitialize
    {
        public virtual string DebugLabel => GetType().Name;
        public virtual void Initialize() { }
    }
}

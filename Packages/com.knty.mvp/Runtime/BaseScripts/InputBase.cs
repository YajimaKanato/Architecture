using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class InputBase : MonoBehaviour, IInitialize
    {
        [SerializeField] string _id;
        public virtual string DebugLabel => GetType().Name;
        public abstract void Initialize();
    }
}

using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class ViewBase : MonoBehaviour, IInitialize
    {
        [SerializeField] string _id;
        protected IEventHub _eventHub;
        public IEventHub EventHub => _eventHub;
        public virtual string DebugLabel => GetType().Name;
        public abstract void Initialize();
        public abstract void InitializeState(IEventHub eventHub);
    }
}

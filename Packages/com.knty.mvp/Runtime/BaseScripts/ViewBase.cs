using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class ViewBase : MonoBehaviour, IInitialize
    {
        [SerializeField] string _id;
        protected StateMachine _stateMachine = new();
        protected IState[] _stateCache;
        protected IEventHub _eventHub;
        public virtual string DebugLabel => GetType().Name;
        public abstract void Initialize();
        public abstract void InitializeState(IEventHub eventHub);
    }
}

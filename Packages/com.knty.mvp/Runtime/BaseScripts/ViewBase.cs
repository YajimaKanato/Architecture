using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class ViewBase : MonoBehaviour, IInitialize
    {
        [SerializeField] string _id;
        protected StateMachine _stateMachine = new();
        protected IState[] _stateArray;
        public virtual string DebugLabel => GetType().Name;
        public abstract void Initialize();
    }
}

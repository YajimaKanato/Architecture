using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class ViewBase : MonoBehaviour
    {
        [SerializeField] protected ID _id;
        protected IEventHub _eventHub;
        public ID ID => _id;
        public IEventHub EventHub => _eventHub;
        public abstract void Initialize(ViewModelStorage storage, IEventHub eventHub);
    }
}

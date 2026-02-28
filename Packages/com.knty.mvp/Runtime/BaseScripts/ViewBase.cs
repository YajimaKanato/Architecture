using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class ViewBase : MonoBehaviour
    {
        [SerializeField] protected string _id;
        protected IEventHub _eventHub;
        public string ID => _id;
        public IEventHub EventHub => _eventHub;
        public abstract void Initialize(ViewModelStorage storage, IEventHub eventHub);
    }
}

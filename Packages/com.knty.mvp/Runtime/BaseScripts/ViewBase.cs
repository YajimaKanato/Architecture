using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class ViewBase : MonoBehaviour
    {
        [SerializeField] string _id;
        protected IEventHub _eventHub;
        public IEventHub EventHub => _eventHub;
        public abstract void Initialize(ViewModelStorage storage, IEventHub eventHub);
    }
}

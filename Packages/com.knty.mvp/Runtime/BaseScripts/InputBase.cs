using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class InputBase : MonoBehaviour
    {
        [SerializeField] protected string _id;
        protected IEventHub _inputHub;
        public void SetEventHub(IEventHub inputHub) => _inputHub = inputHub;
    }
}

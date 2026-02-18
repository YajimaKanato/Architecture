using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public class MVPManager : MonoBehaviour, IInitialize
    {
        [SerializeField] bool _isDDOL = true;
        RuntimeModelStorage _runtimeModelStorage;
        PresenterRegistry _presenterRegistry;

        static MVPManager _instance;

        public string DebugLabel => $"{GetType().Name}";

        public void Initialize()
        {
            _runtimeModelStorage = new RuntimeModelStorage();
            _presenterRegistry = new PresenterRegistry();
        }

        private void Awake()
        {
            if (_isDDOL)
            {
                if (_instance == null)
                {
                    _instance = this;
                    DontDestroyOnLoad(gameObject);
                    Initialize();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Initialize();
            }
        }

        private void OnDestroy()
        {
            _instance = null;
        }
    }
}

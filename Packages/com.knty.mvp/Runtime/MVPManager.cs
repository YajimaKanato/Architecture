using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public class MVPManager : MonoBehaviour
    {
        [SerializeField] bool _isDDOL = true;
        RuntimeModelStorage _runtimeModelStorage;

        static MVPManager _instance;

        public void Initialize()
        {
            _runtimeModelStorage = new RuntimeModelStorage();
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

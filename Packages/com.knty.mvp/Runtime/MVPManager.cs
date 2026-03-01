using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public class MVPManager : MonoBehaviour
    {
        [SerializeField] bool _isDDOL = true;
        RuntimeModelStorage _runtimeModelStorage;
        ViewModelStorage _viewModelStorage;
        IEventHub _inputHub;
        IEventHub _eventHub;

        static MVPManager _instance;

        public void Initialize()
        {
            _inputHub = new DefaultInputHub();
            _eventHub = new DefaultEventHub();
            _runtimeModelStorage = new RuntimeModelStorage();
            _viewModelStorage = new ViewModelStorage();

            var inputs = FindObjectsByType<InputBase>(FindObjectsSortMode.None);
            foreach (var input in inputs)
            {

            }

            var views = FindObjectsByType<ViewBase>(FindObjectsSortMode.None);
            foreach (var view in views)
            {
                view.Initialize(_viewModelStorage, _eventHub);
            }
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

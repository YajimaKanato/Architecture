using UnityEngine;

namespace KNTyArch.Runtime
{
    public class KNTyArchManager : MonoBehaviour
    {
        [SerializeField] bool _isDDOL = true;
        [SerializeField] ModelCollection _modelCollection;
        PresenterFactoryStateMachine _presenterFactory;
        RuntimeModelStorage _runtimeModelStorage;
        ViewModelStorage _viewModelStorage;
        IEventHub _inputHub;
        IEventHub _eventHub;

        static KNTyArchManager _instance;
        public static KNTyArchManager Instance => _instance;

        public void Initialize()
        {
            _inputHub = new DefaultInputHub();
            _eventHub = new DefaultEventHub();
            _runtimeModelStorage = new RuntimeModelStorage(_modelCollection);
            _viewModelStorage = new ViewModelStorage(_modelCollection);
            _presenterFactory = new PresenterFactoryStateMachine(_runtimeModelStorage, _viewModelStorage, _inputHub, _eventHub);

            var inputs = FindObjectsByType<InputBase>(FindObjectsSortMode.None);
            foreach (var input in inputs)
            {
                input.SetInputHub(_inputHub);
                _runtimeModelStorage.TryRegister(input.ModelType(), input.ID);
                _viewModelStorage.TryRegister(input.ModelType(), input.ID);
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

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KNTyArch.Runtime
{
    public class KNTyArchManager : MonoBehaviour
    {
        [SerializeField] bool _isDDOL = true;
        [SerializeField] DefinitionCollection _modelCollection;
        readonly Dictionary<string, IPresenterFactory> _presenterFactoryDict = new()
        {

        };
        PresenterFactoryStateMachine _presenterFactory;

        static KNTyArchManager _instance;
        public static KNTyArchManager Instance => _instance;

        public void Initialize()
        {
            foreach (var presenterFactory in _presenterFactoryDict.Values)
            {
                presenterFactory.GeneratePresenter();
            }
            _presenterFactory = new PresenterFactoryStateMachine();
            SceneManager.sceneLoaded += OnSceneLoaded;

            var inputs = FindObjectsByType<InputBase>(FindObjectsSortMode.None);
            foreach (var input in inputs)
            {
                RuntimeStorage.TryRegister(input.ModelType(), input.ID);
                ViewDataStorage.TryRegister(input.ModelType(), input.ID);
            }

            var views = FindObjectsByType<ViewBase>(FindObjectsSortMode.None);
            foreach (var view in views)
            {
                view.Initialize();
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

        void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (_presenterFactoryDict.TryGetValue(scene.name, out var presenterFactory)) _presenterFactory.ChangeFactory(presenterFactory);
        }
    }
}

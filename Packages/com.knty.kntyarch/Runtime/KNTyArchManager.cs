using UnityEngine;
using UnityEngine.SceneManagement;

namespace KNTyArch.Runtime
{
    /// <summary>デモマネージャークラス</summary>
    public class KNTyArchManager : MonoBehaviour
    {
        [SerializeField] bool _isDDOL = true;
        [SerializeField] DefinitionCollection _modelCollection;

        static KNTyArchManager _instance;
        public static KNTyArchManager Instance => _instance;

        public void Initialize()
        {
            //SceneManager.sceneLoaded += OnSceneLoaded;

            

            var views = FindObjectsByType<ViewBase>(FindObjectsSortMode.None);
            foreach (var view in views)
            {
                view.SubscribeEvent();
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

        }
    }
}

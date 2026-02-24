#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScriptWindow
    {
        string _viewName;

        [MenuItem("MVP/Create/Script/View && PresenterCore")]
        [MenuItem("Assets/Create/MVP/View && PresenterCore")]
        static void OpenCreateViewAndPresenterFromMenu()
        {
            OpenCreateViewAndPresenter();
            if (EditorApplication.isCompiling || EditorApplication.isUpdating)
                SessionState.SetBool("OpenCreateViewAndPresenterFromMenu", true);
        }

        [InitializeOnLoadMethod]
        static void ResumeCreatingViewAndPresenter()
        {
            if (!SessionState.GetBool("OpenCreateViewAndPresenterFromMenu", false)) return;
            SessionState.EraseBool("OpenCreateViewAndPresenterFromMenu");
            OpenCreateViewAndPresenter();
        }

        static void OpenCreateViewAndPresenter()
        {
            var window = GetWindow<CreateMVPScriptWindow>("Create View & Presenter");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._viewName = "New";
            window._createMenu = CreateMenu.ViewAndPresenter;
        }

        void ViewAndPresenterWindow()
        {
            GUILayout.Label("Create", EditorStyles.boldLabel);
            _viewName = EditorGUILayout.TextField("ScriptName", _viewName);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_viewName)))
            {
                _isFinished = GUILayout.Button("Create");
                var e = Event.current;
                if (!string.IsNullOrEmpty(_viewName) &&
                    e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    _isFinished = true;
                    e.Use();
                }
                if (_isFinished)
                {
                    CreateMVPScript.CreateView(_viewName);
                    CreateMVPScript.CreatePresenterCore(_viewName, "", "", "");
                    CreateMVPScript.CreatePresenterLifeCycle(_viewName);
                }
            }
        }
    }
}
#endif
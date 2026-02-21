using UnityEngine;
using UnityEditor;
using UnityEditor.ShortcutManagement;

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
        }

        [Shortcut("MVP/Create View && PresenterCore", KeyCode.V, ShortcutModifiers.Control)]
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
                    CreateMVPScript.CreatePresenterCore(_viewName, "", "");
                    CreateMVPScript.CreatePresenterLifeCycle(_viewName);
                }
            }
        }
    }
}

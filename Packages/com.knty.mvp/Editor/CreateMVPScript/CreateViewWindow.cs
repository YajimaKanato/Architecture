#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScriptWindow
    {
        string _viewName;

        [MenuItem("MVP/Create/Script/View")]
        [MenuItem("Assets/Create/MVP/View")]
        static void OpenCreateViewFromMenu()
        {
            OpenCreateView();
            if (EditorApplication.isCompiling || EditorApplication.isUpdating)
                SessionState.SetBool("OpenCreateViewFromMenu", true);
        }

        [InitializeOnLoadMethod]
        static void ResumeCreatingView()
        {
            if (!SessionState.GetBool("OpenCreateViewFromMenu", false)) return;
            SessionState.EraseBool("OpenCreateViewFromMenu");
            OpenCreateView();
        }

        static void OpenCreateView()
        {
            var window = GetWindow<CreateMVPScriptWindow>("Create View");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._viewName = "New";
            window._createMenu = CreateMenu.View;
        }

        void ViewWindow()
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
                }
            }
        }
    }
}
#endif
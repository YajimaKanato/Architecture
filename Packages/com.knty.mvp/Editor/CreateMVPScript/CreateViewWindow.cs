#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        string _viewName;

        [MenuItem("KNTyArch/Create/Script/View")]
        [MenuItem("Assets/Create/KNTyArch/Script/View")]
        static void OpenCreateViewFromMenu()
        {
            OpenCreateView();
        }

        static void OpenCreateView()
        {
            var window = GetWindow<CreateKNTyArchScriptWindow>("Create View");
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
                    CreateKNTyArchScript.CreateView(_viewName);
                }
            }
        }
    }
}
#endif
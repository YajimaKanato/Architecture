#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        string _viewName;

        [MenuItem("KNTyArch/Create/Script/Core/View",true)]
        [MenuItem("Assets/Create/KNTyArch/Script/Core/View",true)]
        static bool ValidateOpenCreateView()
        {
            return ScriptCollection.RuntimeNames.Count > 0;
        }

        [MenuItem("KNTyArch/Create/Script/Core/View")]
        [MenuItem("Assets/Create/KNTyArch/Script/Core/View")]
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
            window._runtimes = ScriptCollection.RuntimeNames.ToArray();
            window._runtimeIndex = 0;
            window._createMenu = CreateMenu.View;
        }

        void ViewWindow()
        {
            GUILayout.Label("View", EditorStyles.boldLabel);
            _viewName = EditorGUILayout.TextField("ScriptName", _viewName);
            _runtimeIndex = EditorGUILayout.Popup("Runtime Type", _runtimeIndex, _runtimes);

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
                    var runtime = _runtimes[_runtimeIndex].Replace("Runtime", "");
                    CreateKNTyArchScript.CreateView(_viewName, runtime);
                }
            }
        }
    }
}
#endif
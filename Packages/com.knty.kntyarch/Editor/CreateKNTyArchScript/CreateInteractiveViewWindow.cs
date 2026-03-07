#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        string _interactiveViewName;
        string[] _runtimes;
        int _runtimeIndex;

        [MenuItem("KNTyArch/Create/Script/Core/InteractiveView", true)]
        [MenuItem("Assets/Create/KNTyArch/Script/Core/InteractiveView", true)]
        static bool ValidateOpenCreateInteractiveView()
        {
            return ScriptCollection.RuntimeNames.Count > 0;
        }

        [MenuItem("KNTyArch/Create/Script/Core/InteractiveView")]
        [MenuItem("Assets/Create/KNTyArch/Script/Core/InteractiveView")]
        static void OpenCreateInteractiveViewFromMenu()
        {
            OpenCreateInteractiveView();
        }

        static void OpenCreateInteractiveView()
        {
            var window = GetWindow<CreateKNTyArchScriptWindow>("Create InteractiveView");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._interactiveViewName = "New";
            window._runtimes = ScriptCollection.RuntimeNames.ToArray();
            window._runtimeIndex = 0;
            window._createMenu = CreateMenu.InteractiveView;
        }

        void InteractiveViewWindow()
        {
            GUILayout.Label("InteractiveView", EditorStyles.boldLabel);
            _interactiveViewName = EditorGUILayout.TextField("ScriptName", _interactiveViewName);
            _runtimeIndex = EditorGUILayout.Popup("Runtime Type", _runtimeIndex, _runtimes);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_interactiveViewName)))
            {
                _isFinished = GUILayout.Button("Create");
                var e = Event.current;
                if (e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    _isFinished = true;
                    e.Use();
                }
                if (_isFinished)
                {
                    var runtimeName = _runtimes[_runtimeIndex].Replace("Runtime", "");
                    CreateKNTyArchScript.CreateInteractiveView(_interactiveViewName, runtimeName);
                }
            }
        }
    }
}
#endif
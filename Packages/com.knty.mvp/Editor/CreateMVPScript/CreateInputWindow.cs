#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        string _inputName;
        string[] _runtimes;
        int _runtimeIndex;

        [MenuItem("KNTyArch/Create/Script/Input", true)]
        [MenuItem("Assets/Create/KNTyArch/Script/Input", true)]
        static bool ValidateOpenCreateInput()
        {
            return ScriptCollection.RuntimeNames.Count > 0;
        }

        [MenuItem("KNTyArch/Create/Script/Input")]
        [MenuItem("Assets/Create/KNTyArch/Script/Input")]
        static void OpenCreateInputFromMenu()
        {
            OpenCreateInput();
        }

        static void OpenCreateInput()
        {
            var window = GetWindow<CreateKNTyArchScriptWindow>("Create Input");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._inputName = "New";
            window._runtimes = ScriptCollection.RuntimeNames.ToArray();
            window._runtimeIndex = 0;
            window._createMenu = CreateMenu.Input;
        }

        void InputWindow()
        {
            GUILayout.Label("Input", EditorStyles.boldLabel);
            _inputName = EditorGUILayout.TextField("ScriptName", _inputName);
            _runtimeIndex = EditorGUILayout.Popup("Runtime Type", _runtimeIndex, _runtimes);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_inputName)))
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
                    CreateKNTyArchScript.CreateInput(_inputName, runtimeName);
                }
            }
        }
    }
}
#endif
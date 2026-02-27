#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScriptWindow
    {
        string _inputName;

        [MenuItem("MVP/Create/Script/Input")]
        [MenuItem("Assets/Create/MVP/Input")]
        static void OpenCreateInputFromMenu()
        {
            OpenCreateInput();
            if (EditorApplication.isCompiling || EditorApplication.isUpdating)
                SessionState.SetBool("OpenCreateInputFromMenu", true);
        }

        [InitializeOnLoadMethod]
        static void ResumeCreatingInput()
        {
            if (!SessionState.GetBool("OpenCreateInputFromMenu", false)) return;
            SessionState.EraseBool("OpenCreateInputFromMenu");
            OpenCreateInput();
        }

        static void OpenCreateInput()
        {
            var window = GetWindow<CreateMVPScriptWindow>("Create Input");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._inputName = "New";
            window._createMenu = CreateMenu.Input;
        }

        void InputWindow()
        {
            GUILayout.Label("Input", EditorStyles.boldLabel);
            _inputName = EditorGUILayout.TextField("ScriptName", _inputName);

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
                if (_isFinished) CreateMVPScript.CreateInput(_inputName);
            }
        }
    }
}
#endif
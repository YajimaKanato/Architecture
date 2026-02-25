#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScriptWindow
    {
        string[] _presenterNames;
        int _presenterIndex;
        string _inputName;

        [MenuItem("MVP/Create/Script/Input", true)]
        [MenuItem("Assets/Create/MVP/Input", true)]
        static bool ValidateCreatingInput()
        {
            return ScriptCollection.PresenterNames.Count > 0;
        }

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
            Vector2 windowSize = new Vector2(350, 230);
            window.maxSize = window.minSize = windowSize;
            window._presenterNames = ScriptCollection.PresenterNames.ToArray();
            window._presenterIndex = 0;
            window._createMenu = CreateMenu.Input;
        }

        void InputWindow()
        {
            GUILayout.Label("Input", EditorStyles.boldLabel);
            _inputName = EditorGUILayout.TextField("ScriptName", _inputName);
            _presenterIndex = EditorGUILayout.Popup("Presenter Type", _presenterIndex, _presenterNames);

            _isFinished = GUILayout.Button("Create");
            GUILayout.Space(10);
            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_inputName)))
            {
                var e = Event.current;
                if (e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    _isFinished = true;
                    e.Use();
                }
                if (_isFinished)
                {
                    var presenterName = _presenterNames[_presenterIndex].Replace("Presenter", "");
                    CreateMVPScript.CreateInput(_inputName, presenterName);
                }
            }
        }
    }
}
#endif
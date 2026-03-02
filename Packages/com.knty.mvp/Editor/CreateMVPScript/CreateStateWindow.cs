#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        string _stateName;
        string[] _viewNames;
        int _viewIndex;

        [MenuItem("KNTyArch/Create/Script/State", true)]
        [MenuItem("Assets/Create/KNTyArch/Script/State", true)]
        static bool ValidateOpenCreatingState()
        {
            return ScriptCollection.ViewNames.Count > 0;
        }

        [MenuItem("KNTyArch/Create/Script/State")]
        [MenuItem("Assets/Create/KNTyArch/Script/State")]
        static void OpenCreateStateFromMenu()
        {
            OpenCreateState();
        }

        static void OpenCreateState()
        {
            var window = GetWindow<CreateKNTyArchScriptWindow>("Create State");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._stateName = "New";
            window._viewNames = ScriptCollection.ViewNames.ToArray();
            window._viewIndex = 0;
            window._createMenu = CreateMenu.State;
        }

        void StateWindow()
        {
            GUILayout.Label("State", EditorStyles.boldLabel);
            _stateName = EditorGUILayout.TextField("ScriptName", _stateName);
            _viewIndex = EditorGUILayout.Popup("View Type", _viewIndex, _viewNames);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_stateName)))
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
                    var viewName = _viewNames[_viewIndex].Replace("View", "");
                    CreateKNTyArchScript.CreateState(_stateName, viewName);
                }
            }
        }
    }
}
#endif
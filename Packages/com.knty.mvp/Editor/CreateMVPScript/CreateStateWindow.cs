#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScriptWindow
    {
        string _stateName;
        string[] _viewNames;
        int _viewIndex;

        [MenuItem("MVP/Create/Script/State", true)]
        [MenuItem("Assets/Create/MVP/State", true)]
        static bool ValidateOpenCreatingState()
        {
            return ScriptCollection.ViewNames.Count > 0;
        }

        [MenuItem("MVP/Create/Script/State")]
        [MenuItem("Assets/Create/MVP/State")]
        static void OpenCreateStateFromMenu()
        {
            OpenCreateState();
            if (EditorApplication.isCompiling || EditorApplication.isUpdating)
                SessionState.SetBool("OpenCreateState", true);
        }

        [InitializeOnLoadMethod]
        static void ResumeCreatingState()
        {
            if (!SessionState.GetBool("OpenCreateState", false)) return;
            SessionState.EraseBool("OpenCreateState");
            OpenCreateState();
        }

        static void OpenCreateState()
        {
            var window = GetWindow<CreateMVPScriptWindow>("Create State");
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
                    CreateMVPScript.CreateState(_stateName, viewName);
                }
            }
        }
    }
}
#endif
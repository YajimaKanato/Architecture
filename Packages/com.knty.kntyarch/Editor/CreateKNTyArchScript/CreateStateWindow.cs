#if UNITY_EDITOR
using KNTyArch.Runtime;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        enum ViewType
        {
            View,
            InteractiveView
        }

        string _stateName;
        string[] _viewNames;
        int _viewIndex;
        string[] _interactiveViewNames;
        int _interactiveViewIndex;
        ViewType _viewType;

        [MenuItem("KNTyArch/Create/Script/Parts/State", true)]
        [MenuItem("Assets/Create/KNTyArch/Script/Parts/State", true)]
        static bool ValidateOpenCreatingState()
        {
            return ScriptCollection.ViewNames.Count > 0 || ScriptCollection.InteractiveViewNames.Count > 0;
        }

        [MenuItem("KNTyArch/Create/Script/Parts/State")]
        [MenuItem("Assets/Create/KNTyArch/Script/Parts/State")]
        static void OpenCreateStateFromMenu()
        {
            OpenCreateState();
        }

        static void OpenCreateState()
        {
            var window = GetWindow<CreateKNTyArchScriptWindow>("Create State");
            Vector2 windowSize = new Vector2(350, 150);
            window.maxSize = window.minSize = windowSize;
            window._stateName = "New";
            window._viewNames = ScriptCollection.ViewNames.ToArray();
            window._viewIndex = 0;
            window._interactiveViewNames = ScriptCollection.InteractiveViewNames.ToArray();
            window._interactiveViewIndex = 0;
            window._createMenu = CreateMenu.State;
        }

        void StateWindow()
        {
            GUILayout.Label("State", EditorStyles.boldLabel);

            _stateName = EditorGUILayout.TextField("StateName", _stateName);

            GUILayout.Space(10);

            _viewType = (ViewType)GUILayout.Toolbar((int)_viewType, new[] { "View", "InteractView" });

            switch (_viewType)
            {
                case ViewType.View:
                    ViewStateWindow();
                    break;
                case ViewType.InteractiveView:
                    InteractiveViewStateWindow();
                    break;
            }
        }

        void ViewStateWindow()
        {
            _viewIndex = EditorGUILayout.Popup("View Type", _viewIndex, _viewNames);
            GUILayout.FlexibleSpace();
            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_stateName) || _viewNames.Length <= 0))
            {
                _isFinished = GUILayout.Button("Create");
                GUILayout.Space(10);
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
                    CreateKNTyArchScript.CreateViewState(_stateName, viewName);
                }
            }
        }

        void InteractiveViewStateWindow()
        {
            _interactiveViewIndex = EditorGUILayout.Popup("InteractiveView Type", _interactiveViewIndex, _interactiveViewNames);
            GUILayout.FlexibleSpace();
            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_stateName) || _interactiveViewNames.Length <= 0))
            {
                _isFinished = GUILayout.Button("Create");
                GUILayout.Space(10);
                var e = Event.current;
                if (e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    _isFinished = true;
                    e.Use();
                }
                if (_isFinished)
                {
                    var interactiveViewName = _interactiveViewNames[_interactiveViewIndex].Replace("InteractiveView", "");
                    CreateKNTyArchScript.CreateInteractiveViewState(_stateName, interactiveViewName);
                }
            }
        }
    }
}
#endif
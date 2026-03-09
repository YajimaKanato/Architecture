#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        string _interactiveViewName;
        string[] _definitions;
        int _definitionIndex;

        [MenuItem("KNTyArch/Create/Script/Core/InteractiveView", true)]
        [MenuItem("Assets/Create/KNTyArch/Script/Core/InteractiveView", true)]
        static bool ValidateOpenCreateInteractiveView()
        {
            return ScriptCollection.DefinitionNames.Count > 0;
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
            window._definitions = ScriptCollection.DefinitionNames.ToArray();
            window._definitionIndex = 0;
            window._createMenu = CreateMenu.InteractiveView;
        }

        void InteractiveViewWindow()
        {
            GUILayout.Label("InteractiveView", EditorStyles.boldLabel);
            _interactiveViewName = EditorGUILayout.TextField("ScriptName", _interactiveViewName);
            _definitionIndex = EditorGUILayout.Popup("Definition Type", _definitionIndex, _definitions);

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
                    var definitionName = _definitions[_definitionIndex].Replace("Definition", "");
                    CreateKNTyArchScript.CreateInteractiveView(_interactiveViewName, definitionName);
                }
            }
        }
    }
}
#endif
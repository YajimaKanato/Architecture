#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.ShortcutManagement;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScriptWindow
    {
        string _modelName;

        [MenuItem("MVP/Create/Script/Model && RuntimeModel")]
        [MenuItem("Assets/Create/MVP/Model && RuntimeModel")]
        static void OpenCreateModelFromMenu()
        {
            OpenCreateModel();
        }

        [Shortcut("MVP/Create Model && RuntimeModel", KeyCode.M, ShortcutModifiers.Control)]
        static void OpenCreateModel()
        {
            var window = GetWindow<CreateMVPScriptWindow>("Create Models");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._modelName = "New";
            window._createMenu = CreateMenu.Models;
        }

        void ModelWindow()
        {
            GUILayout.Label("Base Name", EditorStyles.boldLabel);
            _modelName = EditorGUILayout.TextField("ScriptName", _modelName);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_modelName)))
            {
                _isFinished = GUILayout.Button("Create");
                var e = Event.current;
                if (!string.IsNullOrEmpty(_modelName) &&
                    e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    _isFinished = true;
                    e.Use();
                }
                if (_isFinished) CreateMVPScript.CreateModels(_modelName);
            }
        }
    }
}
#endif
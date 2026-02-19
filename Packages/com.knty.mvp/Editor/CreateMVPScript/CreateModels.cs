#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScript
    {
        [MenuItem("MVP/Create/Script/Model && RuntimeModel")]
        [MenuItem("Assets/Create/MVP/Model && RuntimeModel", false, 10)]
        static void OpenCreateModelFromMenu()
        {
            OpenCreateModel();
        }

        [Shortcut("MVP/Create Model && RuntimeModel", KeyCode.M, ShortcutModifiers.Control)]
        static void OpenCreateModel()
        {
            var window = GetWindow<CreateMVPScript>("Create Models");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._className = "New";
            window._createMenu = CreateMenu.Models;
        }

        void ModelWindow()
        {
            GUILayout.Label("Base Name", EditorStyles.boldLabel);
            _className = EditorGUILayout.TextField("ScriptName", _className);

            GUILayout.Space(10);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_className)))
            {
                var pressed = GUILayout.Button("Create");
                var e = Event.current;
                if (!string.IsNullOrEmpty(_className) &&
                    e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    pressed = true;
                    e.Use();
                }
                if (pressed)
                {
                    CreateModel(_className);
                    Close();
                }
            }
        }

        void CreateModel(string name)
        {
            var root = EnsureMPVRootFolder();
            var modelPath = EnsureFolder(root, "Model");
            var runtimeModelPath = EnsureFolder(root, "RuntimeModel");

            CreateScript(modelPath, $"{name}Model.cs", Model(name));
            CreateScript(runtimeModelPath, $"{name}RuntimeModel.cs", RuntimeModel(name));

            AssetDatabase.Refresh();
        }
    }
}
#endif
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        string _modelName;

        //[MenuItem("KNTyArch/Create/Script/Core/Models")]
        //[MenuItem("Assets/Create/KNTyArch/Script/Core/Models")]
        static void OpenCreateModelsFromMenu()
        {
            OpenCreateModels();
        }

        static void OpenCreateModels()
        {
            var window = GetWindow<CreateKNTyArchScriptWindow>("Create Models");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._modelName = "New";
            window._createMenu = CreateMenu.Models;
        }

        void ModelWindow()
        {
            GUILayout.Label("Models", EditorStyles.boldLabel);
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
                if (_isFinished) CreateKNTyArchScript.CreateModels(_modelName);
            }
        }
    }
}
#endif
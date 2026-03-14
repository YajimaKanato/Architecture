using UnityEditor;
using UnityEngine;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        string _sceneObjectName;

        //[MenuItem("KNTyArch/Create/Script/Core/SceneObject")]
        //[MenuItem("Assets/Create/KNTyArch/Script/Core/SceneObject")]
        [MenuItem("KNTyArch/Create/SceneObject")]
        [MenuItem("Assets/Create/KNTyArch/SceneObject")]
        static void OpenCreateSceneObjectFromMenu()
        {
            OpenCreateSceneObject();
        }

        static void OpenCreateSceneObject()
        {
            var window = GetWindow<CreateKNTyArchScriptWindow>("Create SceneObject");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._sceneObjectName = "New";
            window._createMenu = CreateMenu.SceneObject;
        }

        void SceneObjectWindow()
        {
            GUILayout.Label("SceneObject", EditorStyles.boldLabel);
            _sceneObjectName = EditorGUILayout.TextField("SceneObjectName", _sceneObjectName);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_sceneObjectName)))
            {
                _isFinished = GUILayout.Button("Create");
                var e = Event.current;
                if (!string.IsNullOrEmpty(_sceneObjectName) &&
                    e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    _isFinished = true;
                    e.Use();
                }
                if (_isFinished) CreateKNTyArchScript.CreateSceneObjectScripts(_sceneObjectName);
            }
        }
    }
}

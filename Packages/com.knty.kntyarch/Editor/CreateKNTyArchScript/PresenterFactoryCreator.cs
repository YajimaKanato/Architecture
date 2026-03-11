#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        string _presenterFactoryName;

        //[MenuItem("KNTyArch/Create/Script/Parts/PresenterFactory")]
        //[MenuItem("Assets/Create/KNTyArch/Script/Parts/PresenterFactory")]
        static void OpenCreatePresenterFactoryFromMenu()
        {
            OpenCreatePresenterFactory();
        }

        static void OpenCreatePresenterFactory()
        {
            var window = GetWindow<CreateKNTyArchScriptWindow>("PresenterFactory");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._presenterFactoryName = "New";
            window._createMenu = CreateMenu.PresenterFactory;
        }

        void PresenterFactoryWindow()
        {
            GUILayout.Label("PresenterFactory", EditorStyles.boldLabel);
            _presenterFactoryName = EditorGUILayout.TextField("ScriptName", _presenterFactoryName);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_presenterFactoryName)))
            {
                _isFinished = GUILayout.Button("Create");
                var e = Event.current;
                if (e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    _isFinished = true;
                    e.Use();
                }
                if (_isFinished) CreateKNTyArchScript.CreatePresenterFactory(_presenterFactoryName);
            }
        }
    }
}
#endif
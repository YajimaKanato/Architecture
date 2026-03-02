#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScriptWindow
    {
        string _presenterFactoryName;

        [MenuItem("MVP/Create/Script/PresenterFactory")]
        [MenuItem("Assets/Create/MVP/Script/PresenterFactory")]
        static void OpenCreatePresenterFactoryFromMenu()
        {
            OpenCreatePresenterFactory();
        }

        static void OpenCreatePresenterFactory()
        {
            var window = GetWindow<CreateMVPScriptWindow>("PresenterFactory");
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
                if (_isFinished) CreateMVPScript.CreatePresenterFactory(_presenterFactoryName);
            }
        }
    }
}
#endif
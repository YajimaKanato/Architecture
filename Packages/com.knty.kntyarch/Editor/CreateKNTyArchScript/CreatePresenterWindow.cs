#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        string _presenterName;

        //[MenuItem("KNTyArch/Create/Script/Core/Presenter")]
        //[MenuItem("Assets/Create/KNTyArch/Script/Core/Presenter")]
        static void OpenCreatePresenterMenu()
        {
            OpenCreatePresenter();
        }

        static void OpenCreatePresenter()
        {
            var window = GetWindow<CreateKNTyArchScriptWindow>("Create Presenter");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._presenterName = "New";
            window._createMenu = CreateMenu.Presenter;
        }

        void PresenterWindow()
        {
            GUILayout.Label("Presenter", EditorStyles.boldLabel);
            _presenterName = EditorGUILayout.TextField("ScriptName", _presenterName);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_presenterName)))
            {
                _isFinished = GUILayout.Button("Create");
                var e = Event.current;
                if (e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    _isFinished = true;
                    e.Use();
                }
                if (_isFinished) CreateKNTyArchScript.CreatePresenter(_presenterName);
            }
        }
    }
}
#endif
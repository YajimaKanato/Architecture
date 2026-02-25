#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScriptWindow
    {
        string _presenterName;

        [MenuItem("MVP/Create/Script/Presenter")]
        [MenuItem("Assets/Create/MVP/Presenter")]
        static void OpenCreatePresenterMenu()
        {
            OpenCreatePresenter();
            if (EditorApplication.isCompiling || EditorApplication.isUpdating)
                SessionState.SetBool("OpenCreatePresenterMenu", true);
        }

        [InitializeOnLoadMethod]
        static void ResumeCreatingPresenter()
        {
            if (!SessionState.GetBool("OpenCreatePresenterMenu", false)) return;
            SessionState.EraseBool("OpenCreatePresenterMenu");
            OpenCreatePresenter();
        }

        static void OpenCreatePresenter()
        {
            var window = GetWindow<CreateMVPScriptWindow>("Create Presenter");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
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
                if (_isFinished) CreateMVPScript.CreatePresenter(_presenterName);
            }
        }
    }
}
#endif
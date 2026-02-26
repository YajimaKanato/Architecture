#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScriptWindow
    {
        string _eventHubName;

        [MenuItem("MVP/Create/Script/EventHub")]
        [MenuItem("Assets/Create/MVP/EventHub")]
        static void OpenCreateEventHubFromMenu()
        {
            OpenCreateEventHub();
            if (EditorApplication.isCompiling || EditorApplication.isUpdating)
                SessionState.SetBool("OpenCreateEventHub", true);
        }

        [InitializeOnLoadMethod]
        static void ResumeCreatingEventHub()
        {
            if (!SessionState.GetBool("OpenCreateEventHub", false)) return;
            SessionState.EraseBool("OpenCreateEventHub");
            OpenCreateEventHub();
        }

        static void OpenCreateEventHub()
        {
            var window = GetWindow<CreateMVPScriptWindow>("Create EventHub");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._eventHubName = "New";
            window._createMenu = CreateMenu.EventHub;
        }

        void EventHubWindow()
        {
            GUILayout.Label("EventHub", EditorStyles.boldLabel);
            _eventHubName = EditorGUILayout.TextField("ScriptName", _eventHubName);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_eventHubName)))
            {
                _isFinished = GUILayout.Button("Create");
                var e = Event.current;
                if (e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    _isFinished = true;
                    e.Use();
                }
                if (_isFinished) CreateMVPScript.CreateEventHub(_viewName);
            }
        }
    }
}
#endif
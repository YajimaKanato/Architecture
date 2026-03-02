#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        string _eventHubName;

        [MenuItem("KNTyArch/Create/Script/EventHub")]
        [MenuItem("Assets/Create/KNTyArch/Script/EventHub")]
        static void OpenCreateEventHubFromMenu()
        {
            OpenCreateEventHub();
        }

        static void OpenCreateEventHub()
        {
            var window = GetWindow<CreateKNTyArchScriptWindow>("Create EventHub");
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
                if (_isFinished) CreateKNTyArchScript.CreateEventHub(_eventHubName);
            }
        }
    }
}
#endif
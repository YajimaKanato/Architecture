using UnityEditor;
using UnityEngine;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow
    {
        string _tokenName;

        //[MenuItem("KNTyArch/Create/Script/Parts/Token")]
        //[MenuItem("Assets/Create/KNTyArch/Script/Parts/Token")]
        [MenuItem("KNTyArch/Create/Token")]
        [MenuItem("Assets/Create/KNTyArch/Token")]
        static void OpenCreateTokenFromMenu()
        {
            OpenCreateToken();
        }

        static void OpenCreateToken()
        {
            var window = GetWindow<CreateKNTyArchScriptWindow>("Create Token");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._tokenName = "New";
            window._createMenu = CreateMenu.Token;
        }

        void TokenWindow()
        {
            GUILayout.Label("Token", EditorStyles.boldLabel);
            _tokenName = EditorGUILayout.TextField("ScriptName", _tokenName);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_tokenName)))
            {
                _isFinished = GUILayout.Button("Create");
                var e = Event.current;
                if (e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    _isFinished = true;
                    e.Use();
                }
                if (_isFinished) CreateKNTyArchScript.CreateToken(_tokenName);
            }
        }
    }
}

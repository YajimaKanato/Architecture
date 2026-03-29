#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace MVPTools.Editor
{
    internal class CreateMVPWindow : EditorWindow
    {
        string _scriptName;
        string _tokenName;
        bool _canInput;
        bool _isOpenWindow;

        private void OnGUI()
        {
            if (_isOpenWindow)
            {
                MVPWindow();
            }
        }

        [MenuItem("MVP/Open MVP Window")]
        static void OpenCreateMVPWindow()
        {
            var window = GetWindow<CreateMVPWindow>("Create \"MVP\"");
            window.maxSize = window.minSize = new Vector2(300, 200);
            window._scriptName = "New";
            window._tokenName = "New";
            window._isOpenWindow = true;
            window._canInput = true;
        }

        void MVPWindow()
        {
            GUILayout.Space(5);
            GUILayout.Label("Create MVP", EditorStyles.boldLabel);
            _scriptName = EditorGUILayout.TextField("ScriptName", _scriptName);
            _canInput = EditorGUILayout.Toggle("Can Input", _canInput);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_scriptName)))
            {
                if (GUILayout.Button("Create MVP"))
                {
                    CreateMVPScripts.CreateModel(_scriptName);
                    CreateMVPScripts.CreateRuntime(_scriptName);
                    CreateMVPScripts.CreatePresenter(_scriptName);
                    CreateMVPScripts.CreateView(_scriptName);
                    CreateMVPScripts.CreateViewCore(_scriptName);
                    if (_canInput) CreateMVPScripts.CreateInput(_scriptName);
                }
            }

            GUILayout.Space(10);
            GUILayout.Label("Create Token", EditorStyles.boldLabel);
            _tokenName = EditorGUILayout.TextField("TokenName", _tokenName);

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_tokenName)))
            {
                if (GUILayout.Button("Create Token")) CreateMVPScripts.CreateToken(_tokenName);
            }

            GUILayout.FlexibleSpace();
            GUI.backgroundColor = Color.red;
            if (GUILayout.Button("Close Window (Close Tab)"))
            {
                _isOpenWindow = false;
                Close();
            }
            GUI.backgroundColor = Color.white;
            GUILayout.Space(10);
        }
    }
}
#endif
#if UNITY_EDITOR
using UnityEditor;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow : EditorWindow
    {
        enum CreateMenu
        {
            None,
            Token,
            SceneObject
        }

        CreateMenu _createMenu = CreateMenu.None;
        bool _isFinished = false;

        private void OnGUI()
        {
            switch (_createMenu)
            {
                case CreateMenu.Token:
                    TokenWindow();
                    break;
                case CreateMenu.SceneObject:
                    SceneObjectWindow();
                    break;
            }

            if (_isFinished)
            {
                AssetDatabase.Refresh();
                Close();
            }
        }
    }
}
#endif
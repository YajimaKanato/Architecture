#if UNITY_EDITOR
using UnityEditor;

namespace KNTyArch.Editor
{
    internal partial class CreateKNTyArchScriptWindow : EditorWindow
    {
        enum CreateMenu
        {
            None,
            Models,
            Presenter,
            PresenterFactory,
            View,
            Input,
            State,
            Token
        }

        CreateMenu _createMenu = CreateMenu.None;
        bool _isFinished = false;

        private void OnGUI()
        {
            switch (_createMenu)
            {
                case CreateMenu.Models:
                    ModelWindow();
                    break;
                case CreateMenu.Presenter:
                    PresenterWindow();
                    break;
                case CreateMenu.PresenterFactory:
                    PresenterFactoryWindow();
                    break;
                case CreateMenu.View:
                    ViewWindow();
                    break;
                case CreateMenu.Input:
                    InteractiveViewWindow();
                    break;
                case CreateMenu.State:
                    StateWindow();
                    break;
                case CreateMenu.Token:
                    TokenWindow();
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
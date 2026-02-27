#if UNITY_EDITOR
using UnityEditor;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScriptWindow : EditorWindow
    {
        enum CreateMenu
        {
            None,
            Models,
            Presenter,
            View,
            Input,
            EventHub,
            State
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
                case CreateMenu.View:
                    ViewWindow();
                    break;
                case CreateMenu.Input:
                    InputWindow();
                    break;
                case CreateMenu.EventHub:
                    EventHubWindow();
                    break;
                case CreateMenu.State:
                    StateWindow();
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
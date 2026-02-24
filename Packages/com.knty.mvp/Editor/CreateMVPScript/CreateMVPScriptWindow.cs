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
            PresenterCore,
            PartialPresenter,
            ViewAndPresenter
        }

        CreateMenu _createMenu = CreateMenu.None;
        bool _isFinished = false;

        private void OnEnable()
        {
            PresenterCoreWindowSetup();
        }

        private void OnGUI()
        {
            switch (_createMenu)
            {
                case CreateMenu.Models:
                    ModelWindow();
                    break;
                case CreateMenu.PresenterCore:
                    PresenterCoreWindow();
                    break;
                case CreateMenu.PartialPresenter:
                    PartialPresenterWindow();
                    break;
                case CreateMenu.ViewAndPresenter:
                    ViewAndPresenterWindow();
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
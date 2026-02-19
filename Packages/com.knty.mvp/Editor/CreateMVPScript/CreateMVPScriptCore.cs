#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.ShortcutManagement;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScript : EditorWindow
    {
        enum CreateMenu
        {
            None,
            Models,
            PresenterCore,
            PartialPresenter,
            ViewAndPresenter
        }

        string _className = "New";
        CreateMenu _createMenu = CreateMenu.None;

        static string Model(string name) => ModelTemplate.Model(name);
        static string RuntimeModel(string name) => RuntimeModelTemplate.RuntimeModel(name);
        static string PresenterCore(string name) => PresenterTemplate.PresenterCore(name);
        static string PartialPresenter(string className, string modelName) => PresenterTemplate.PartialPresenter(className, modelName);
        static string View(string name) => ViewTemplate.View(name);

        private void OnGUI()
        {
            switch (_createMenu)
            {
                case CreateMenu.Models:
                    ModelWindow();
                    break;
                case CreateMenu.PresenterCore:
                    break;
                case CreateMenu.PartialPresenter:
                    PartialPresenterWindow();
                    break;
                case CreateMenu.ViewAndPresenter:
                    break;
            }
        }

        #region View & Presenter
        [MenuItem("MVP/Create/Script/View && Presenter")]
        [MenuItem("Assets/Create/MVP/View && Presenter", false, 20)]
        static void OpenCreateViewAndPresenterFromMenu()
        {
            OpenCreateViewAndPresenter();
        }

        [Shortcut("MVP/Create View && Presenter", KeyCode.V, ShortcutModifiers.Control)]
        static void OpenCreateViewAndPresenter()
        {
            var window = GetWindow<CreateMVPScript>("Create View && Presenter");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._className = "New";
            window._createMenu = CreateMenu.ViewAndPresenter;
        }

        static void CreateViewAndPresenter(string name)
        {
            var root = EnsureMPVRootFolder();
            var presenterPath = EnsureFolder(root, "Presenter");
            var viewPath = EnsureFolder(root, "View");

            CreateScript(presenterPath, $"{name}Presenter.cs", PresenterCore(name));
            CreateScript(viewPath, $"{name}View.cs", View(name));

            AssetDatabase.Refresh();
        }
        #endregion

        static string EnsureMPVRootFolder()
        {
            EnsureFolder("Assets", "Scripts");
            return EnsureFolder("Assets/Scripts", "MVP");
        }

        static string EnsureFolder(string parent, string folderName)
        {
            if (!AssetDatabase.IsValidFolder($"{parent}/{folderName}"))
            {
                AssetDatabase.CreateFolder(parent, folderName);
            }

            return $"{parent}/{folderName}";
        }

        static void CreateScript(string path, string scriptName, string content)
        {
            var fullPath = Path.Combine(path, scriptName);

            bool overwritten = false;

            if (File.Exists(fullPath))
            {
                var overwrite = EditorUtility.DisplayDialog(
                    "File Already Exists",
                    $"{scriptName} already exists.\n\nDo you want to overwrite it?",
                    "Yes",
                    "No"
                );

                if (!overwrite) return;

                overwritten = true;
            }
            File.WriteAllText(fullPath, content);
            EditorApplication.delayCall += () =>
            {
                var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(fullPath);
                Debug.Log(
                    overwritten
                        ? $"Overwrite \"{scriptName}\""
                        : $"Add \"{scriptName}\" under \"{path}\"",
                    mono
                );
            };

        }
    }
}
#endif
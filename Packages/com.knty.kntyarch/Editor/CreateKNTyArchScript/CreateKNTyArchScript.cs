#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

namespace KNTyArch.Editor
{
    internal static class CreateKNTyArchScript
    {
        static string EnsureKNTyArchRootFolder()
        {
            EnsureFolder("Assets", "Scripts");
            return EnsureFolder("Assets/Scripts", "KNTyArch");
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
            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
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

        internal static void CreateModels(string className)
        {
            var root = EnsureKNTyArchRootFolder();
            root = EnsureFolder(root, "Models");
            var definitionPath = EnsureFolder(root, "Definition");
            var runtimePath = EnsureFolder(root, "Runtime");
            var viewDataPath = EnsureFolder(root, "ViewData");

            CreateScript(definitionPath, $"{className}Definition.cs", DefinitionTemplate.Definition(className));
            CreateScript(runtimePath, $"{className}Runtime.cs", RuntimeTemplate.Runtime(className));
            CreateScript(viewDataPath, $"{className}ViewData.cs", ViewDataTemplate.ViewData(className));
        }

        internal static void CreatePresenter(string className)
        {
            var root = EnsureKNTyArchRootFolder();
            var path = EnsureFolder(root, "Presenter");

            CreateScript(path, $"{className}Presenter.cs", PresenterTemplate.Presenter(className));
        }

        internal static void CreateView(string className)
        {
            var root = EnsureKNTyArchRootFolder();
            var path = EnsureFolder(root, "View");

            CreateScript(path, $"{className}View.cs", ViewTemplate.View(className));
        }

        internal static void CreateInteractiveView(string className, string runtimeName)
        {
            var root = EnsureKNTyArchRootFolder();
            var path = EnsureFolder(root, "InteractiveView");

            CreateScript(path, $"{className}InteractiveView.cs", InteractiveViewTemplate.InteractiveView(className, runtimeName));
        }

        internal static void CreateViewState(string className, string viewName)
        {
            var root = EnsureKNTyArchRootFolder();
            root = EnsureFolder(root, "State");
            var path = EnsureFolder(root, $"{viewName}ViewState");

            CreateScript(path, $"{viewName}View{className}State.cs", StateTemplate.ViewState(className, viewName));
        }

        internal static void CreateInteractiveViewState(string className, string interactiveViewName)
        {
            var root = EnsureKNTyArchRootFolder();
            root = EnsureFolder(root, "State");
            var path = EnsureFolder(root, $"{interactiveViewName}IVState");

            CreateScript(path, $"{interactiveViewName}IV{className}State.cs", StateTemplate.InteractiveViewState(className, interactiveViewName));
        }

        internal static void CreatePresenterFactory(string className)
        {
            var root = EnsureKNTyArchRootFolder();
            var path = EnsureFolder(root, "PresenterFactory");

            CreateScript(path, $"{className}PresenterFactory.cs", PresenterFactoryTemplate.PresenterFactory(className));
        }

        internal static void CreateToken(string className)
        {
            var root = EnsureKNTyArchRootFolder();
            var path = EnsureFolder(root, "Token");

            CreateScript(path, $"{className}Token.cs", TokenTemplate.Token(className));
        }
    }
}
#endif
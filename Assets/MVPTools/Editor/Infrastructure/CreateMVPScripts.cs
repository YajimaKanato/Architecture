#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace MVPTools.Editor
{
    internal static class CreateMVPScripts
    {
        static string EnsureRootFolder()
        {
            return EnsureFolder("Assets", "Scripts");
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

        internal static void CreateModel(string className)
        {
            var root = EnsureRootFolder();
            var path = EnsureFolder(root, className);

            CreateScript(path, $"{className}Model.cs", ModelTemplate.Model(className));
        }

        internal static void CreateRuntime(string className)
        {
            var root = EnsureRootFolder();
            var path = EnsureFolder(root, className);

            CreateScript(path, $"{className}Runtime.cs", RuntimeTemplate.Runtime(className));
        }

        internal static void CreatePresenter(string className)
        {
            var root = EnsureRootFolder();
            var path = EnsureFolder(root, className);

            CreateScript(path, $"{className}Presenter.cs", PresenterTemplate.Presenter(className));
        }

        internal static void CreateView(string className)
        {
            var root = EnsureRootFolder();
            root = EnsureFolder(root, className);
            var path = EnsureFolder(root, "View");

            CreateScript(path, $"{className}View_View.cs", ViewTemplate.View(className));
        }

        internal static void CreateInput(string className)
        {
            var root = EnsureRootFolder();
            root = EnsureFolder(root, className);
            var path = EnsureFolder(root, "View");

            CreateScript(path, $"{className}View_Input.cs", InputTemplate.Input(className));
        }

        internal static void CreateViewCore(string className)
        {
            var root = EnsureRootFolder();
            root = EnsureFolder(root, className);
            var path = EnsureFolder(root, "View");

            CreateScript(path, $"{className}View_Core.cs", ViewCoreTemplate.ViewCore(className));
        }

        internal static void CreateToken(string tokenName)
        {
            var root = EnsureRootFolder();
            var path = EnsureFolder(root, "Token");

            CreateScript(path, $"{tokenName}Token.cs", TokenTemplate.Token(tokenName));
        }
    }
}
#endif
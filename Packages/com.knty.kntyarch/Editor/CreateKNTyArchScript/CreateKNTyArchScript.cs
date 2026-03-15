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

        internal static void CreateSceneObjectScripts(string name)
        {
            var root = EnsureKNTyArchRootFolder();
            var path = EnsureFolder(root, name);

            CreateScript(path, $"{name}Definition.cs", DefinitionTemplate.Definition(name));
            CreateScript(path, $"{name}Runtime.cs", RuntimeTemplate.Runtime(name));
            CreateScript(path, $"{name}ViewData.cs", ViewDataTemplate.ViewData(name));
            CreateScript(path, $"{name}Presenter.cs", PresenterTemplate.Presenter(name));
            CreateScript(path, $"{name}InteractiveView.cs", InteractiveViewTemplate.InteractiveView(name));
            CreateScript(path, $"{name}Factory.cs", ObjectFactoryTemplate.ObjectFactory(name));
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
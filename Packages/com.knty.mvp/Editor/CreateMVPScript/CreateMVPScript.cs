#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

namespace KNTy.MVP.Editor
{
    internal static class CreateMVPScript
    {
        static string EnsureMVPRootFolder()
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

        internal static void CreateModels(string className)
        {
            var root = EnsureMVPRootFolder();
            var modelPath = EnsureFolder(root, "Model");
            var runtimeModelPath = EnsureFolder(root, "RuntimeModel");

            CreateScript(modelPath, $"{className}Model.cs", ModelTemplate.Model(className));
            CreateScript(runtimeModelPath, $"{className}RuntimeModel.cs", RuntimeModelTemplate.RuntimeModel(className));
        }

        internal static void CreatePresenterCore(string className, string argument, string variable, string assignment)
        {
            var root = EnsureMVPRootFolder();
            root = EnsureFolder(root, "Presenter");
            var path = EnsureFolder(root, $"{className}Presenter");
            className = className.Replace("Presenter", "");

            CreateScript(path, $"{className}PresenterCore.cs", PresenterTemplate.PresenterCore(className, argument, variable, assignment));
        }

        internal static void CreatePresenterLifeCycle(string className)
        {
            var root = EnsureMVPRootFolder();
            root = EnsureFolder(root, "Presenter");
            var path = EnsureFolder(root, $"{className}Presenter");

            CreateScript(path, $"{className}PresenterLifeCycle.cs", PresenterTemplate.PresenterLifeCycle(className));
        }

        internal static void CreatePartialPresenter(string className, string modelName)
        {
            var root = EnsureMVPRootFolder();
            root = EnsureFolder(root, "Presenter");
            var path = EnsureFolder(root, $"{className}Presenter");
            className = className.Replace("Presenter", "");
            modelName = modelName.Replace("RuntimeModel", "");

            CreateScript(path, $"{className}Presenter_{modelName}.cs", PresenterTemplate.PartialPresenter(className, modelName));
        }

        internal static void CreateView(string className)
        {
            var root = EnsureMVPRootFolder();
            var path = EnsureFolder(root, "View");

            CreateScript(path, $"{className}View.cs", ViewTemplate.View(className));
        }
    }
}
#endif
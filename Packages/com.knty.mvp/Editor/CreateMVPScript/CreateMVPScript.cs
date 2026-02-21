#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

namespace KNTy.MVP.Editor
{
    internal static class CreateMVPScript
    {
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

        internal static void CreateModels(string className)
        {
            var root = EnsureMPVRootFolder();
            var modelPath = EnsureFolder(root, "Model");
            var runtimeModelPath = EnsureFolder(root, "RuntimeModel");

            CreateScript(modelPath, $"{className}Model.cs", ModelTemplate.Model(className));
            CreateScript(runtimeModelPath, $"{className}RuntimeModel.cs", RuntimeModelTemplate.RuntimeModel(className));

            AssetDatabase.Refresh();
        }

        internal static void CreatePresenterCore(string className, string argument, string assignment)
        {
            var root = EnsureMPVRootFolder();
            root = EnsureFolder(root, "Presenter");
            var path = EnsureFolder(root, className);

            CreateScript(path, $"{className}PresenterCore.cs", PresenterTemplate.PresenterCore(className, argument, assignment));

            AssetDatabase.Refresh();
        }

        internal static void CreatePresenterLifeCycle(string className)
        {
            var root = EnsureMPVRootFolder();
            root = EnsureFolder(root, "Presenter");
            var path = EnsureFolder(root, className);

            CreateScript(path, $"{className}PresenterLifeCycle.cs", PresenterTemplate.PresenterLifeCycle(className));

            AssetDatabase.Refresh();
        }

        internal static void CreatePartialPresenter(string className, string modelName)
        {
            var root = EnsureMPVRootFolder();
            root = EnsureFolder(root, "Presenter");
            var path = EnsureFolder(root, className);
            className = className.Replace("Presenter", "");
            modelName = modelName.Replace("RuntimeModel", "");

            CreateScript(path, $"{className}Presenter_{modelName}.cs", PresenterTemplate.PartialPresenter(className, modelName));

            AssetDatabase.Refresh();
        }

        internal static void CreateView(string className)
        {
            var root = EnsureMPVRootFolder();
            var path = EnsureFolder(root, "View");

            CreateScript(path, $"{className}View.cs", ViewTemplate.View(className));

            AssetDatabase.Refresh();
        }
    }
}
#endif
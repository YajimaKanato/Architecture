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
            root = EnsureFolder(root, "Models");
            var modelPath = EnsureFolder(root, "Model");
            var runtimeModelPath = EnsureFolder(root, "RuntimeModel");
            var viewModelPath = EnsureFolder(root, "ViewModel");

            CreateScript(modelPath, $"{className}Model.cs", ModelTemplate.Model(className));
            CreateScript(runtimeModelPath, $"{className}RuntimeModel.cs", RuntimeModelTemplate.RuntimeModel(className));
            CreateScript(viewModelPath, $"{className}ViewModel.cs", ViewModelTemplate.ViewModel(className));
        }

        internal static void CreatePresenter(string className)
        {
            var root = EnsureMVPRootFolder();
            var path = EnsureFolder(root, "Presenter");

            CreateScript(path, $"{className}Presenter.cs", PresenterTemplate.Presenter(className));
        }

        internal static void CreateView(string className)
        {
            var root = EnsureMVPRootFolder();
            var path = EnsureFolder(root, "View");

            CreateScript(path, $"{className}View.cs", ViewTemplate.View(className));
        }

        internal static void CreateInput(string className)
        {
            var root = EnsureMVPRootFolder();
            var path = EnsureFolder(root, "Input");

            CreateScript(path, $"{className}Input.cs", InputTemplate.Input(className));
        }

        internal static void CreateEventHub(string className)
        {
            var root = EnsureMVPRootFolder();
            var path = EnsureFolder(root, "EventHub");

            CreateScript(path, $"{className}EventHub.cs", EventHubTemplate.EventHub(className));
        }

        internal static void CreateState(string className, string viewName)
        {
            var root = EnsureMVPRootFolder();
            root = EnsureFolder(root, "State");
            var path = EnsureFolder(root, $"{viewName}View");

            CreateScript(path, $"{className}State.cs", StateTemplate.State(className, viewName));
        }
    }
}
#endif
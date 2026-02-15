#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.ShortcutManagement;

/// <summary>
///
/// </summary>
/// <remarks>
/// MVPパターンを意識した開発をサポートするクラス
/// </remarks>
public class CreateMVPScript : EditorWindow
{
    enum CreateMenu
    {
        None,
        Models,
        ViewAndPresenter
    }

    string _className = "New";
    static CreateMenu _createMenu = CreateMenu.None;

    private void OnGUI()
    {
        GUILayout.Label("Base Name", EditorStyles.boldLabel);
        _className = EditorGUILayout.TextField("ScriptName", _className);

        GUILayout.Space(10);

        using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_className)))
        {
            if (GUILayout.Button("Create"))
            {
                switch (_createMenu)
                {
                    case CreateMenu.Models:
                        CreateModel(_className);
                        break;
                    case CreateMenu.ViewAndPresenter:
                        CreateViewAndPresenter(_className);
                        break;
                    default:
                        break;
                }
                Close();
            }
        }
    }

    #region Model
    [MenuItem("Assets/Create/MVP/Model && RuntimeModel")]
    static void OpenCreateModelFromMenu()
    {
        OpenCreateModel();
    }

    [Shortcut("MVP/Create Model && RuntimeModel", KeyCode.M, ShortcutModifiers.Control)]
    static void OpenCreateModel()
    {
        var window = GetWindow<CreateMVPScript>("Create Models");
        Vector2 windowSize = new Vector2(350, 100);
        window.maxSize = window.minSize = windowSize;
        _createMenu = CreateMenu.Models;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// ～Model.csと～RuntimeModel.csを作成するメソッド
    /// </remarks>
    /// <param name="name">ScriptName</param>
    static void CreateModel(string name)
    {
        EnsureFolder("Assets", "Scripts");
        EnsureFolder("Assets/Scripts", "MVP");
        var root = "Assets/Scripts/MVP";
        var modelPath = EnsureFolder(root, "Model");
        var runtimeModelPath = EnsureFolder(root, "RuntimeModel");

        CreateScript(modelPath, $"{name}Model.cs", ModelTemplate(name));
        CreateScript(runtimeModelPath, $"{name}RuntimeModel.cs", RuntimeModelTemplate(name));

        AssetDatabase.Refresh();
    }
    #endregion
    #region View & Presenter
    [MenuItem("Assets/Create/MVP/View && Presenter")]
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
        _createMenu = CreateMenu.ViewAndPresenter;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// ～Presenter.csと～View.csを作成するメソッド
    /// </remarks>
    /// <param name="name">ScriptName</param>
    static void CreateViewAndPresenter(string name)
    {
        EnsureFolder("Assets", "Scripts");
        EnsureFolder("Assets/Scripts", "MVP");
        var root = "Assets/Scripts/MVP";
        var presenterPath = EnsureFolder(root, "Presenter");
        var ViewPath = EnsureFolder(root, "View");

        CreateScript(presenterPath, $"{name}Presenter.cs", PresenterTemplate(name));
        CreateScript(ViewPath, $"{name}View.cs", ViewTemplate(name));

        AssetDatabase.Refresh();
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 指定のフォルダーがなければ作成しフォルダーのパスを返すメソッド
    /// </remarks>
    /// <param name="parent">ParentFolderPath</param>
    /// <param name="folderName">Creating FolderName</param>
    /// <returns>FolderPath</returns>
    static string EnsureFolder(string parent, string folderName)
    {
        if (!AssetDatabase.IsValidFolder($"{parent}/{folderName}"))
        {
            AssetDatabase.CreateFolder(parent, folderName);
        }

        return $"{parent}/{folderName}";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 指定のフォルダーにテンプレートに沿ったスクリプトを作成するメソッド
    /// </remarks>
    /// <param name="path">Creating Script Path</param>
    /// <param name="scriptName">Creating Script Name</param>
    /// <param name="content"></param>
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
            if (overwritten)
                Debug.Log($"Overwrite \"{scriptName}\".");
            else
                Debug.Log($"Add \"{scriptName}\" under \"{path}\".");
        };
    }


    static string ModelTemplate(string name) =>
$@"using UnityEngine;

[CreateAssetMenu(fileName = ""{name}Model"", menuName = ""Models/{name}Model"")]
public class {name}Model : ModelBase<{name}RuntimeModel>
{{
    public override {name}RuntimeModel CreateRuntimeModel()
    {{
        return new {name}RuntimeModel(this);
    }}
}}";

    static string RuntimeModelTemplate(string name) =>
$@"public class {name}RuntimeModel : IRuntime
{{
    public {name}RuntimeModel({name}Model model)
    {{

    }}
}}";

    static string PresenterTemplate(string name) =>
        "";

    static string ViewTemplate(string name) =>
        "";
}
#endif
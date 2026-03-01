#if UNITY_EDITOR
using UnityEditor;
#endif

using KNTy.MVP.Runtime;

public class NewModel : ModelBase<NewRuntimeModel, NewViewModel>
{
    public override NewRuntimeModel CreateTypedRuntimeModel()
    {
        return new NewRuntimeModel(this);
    }

    public override NewViewModel CreateTypedViewModel()
    {
        return new NewViewModel(this);
    }

#if UNITY_EDITOR

    [MenuItem("Assets/Create/MVP/Asset/Models/NewModel")]
    static void CreateNewModel()
    {
        var model = CreateInstance<NewModel>();
        EnsureFolderExists();
        AssetDatabase.CreateAsset(model, "Assets/ModelAssets/NewModel.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = model;
    }

    static void EnsureFolderExists()
    {
        var fullPath = "Assets/ModelAssets";

        if (AssetDatabase.IsValidFolder(fullPath)) return;

        var parts = fullPath.Split('/');
        string current = parts[0];

        for (int i = 1; i < parts.Length; i++)
        {
            string next = $"{current}/{parts[i]}";
            if (!AssetDatabase.IsValidFolder(next))
            {
                AssetDatabase.CreateFolder(current, parts[i]);
            }
            current = next;
        }
    }
#endif
}
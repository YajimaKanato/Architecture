#if UNITY_EDITOR
using UnityEditor;
#endif
using KNTyArch.Runtime;
using UnityEngine;

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

    [MenuItem("Assets/Create/KNTyArch/Asset/Models/NewModel")]
    static void CreateModel()
    {
        ModelAssetCreator.CreateModelAsset<NewModel>();
    }
#endif
}
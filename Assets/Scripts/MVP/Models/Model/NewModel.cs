#if UNITY_EDITOR
using UnityEditor;
#endif
using KNTy.MVP.Runtime;
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

    [MenuItem("Assets/Create/MVP/Asset/Models/NewModel")]
    static void CreateNewModel()
    {
        ModelAssetCreator.CreateModelAsset<NewModel>();
    }
#endif
}
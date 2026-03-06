#if UNITY_EDITOR
using UnityEditor;
#endif
using KNTyArch.Runtime;
using UnityEngine;

public class NewDefinition : DefinitionBase<NewRuntime, NewViewData>
{

    #region Non-Edit
    public override NewRuntime CreateTypedRuntime()
    {
        return new NewRuntime(this);
    }

    public override NewViewData CreateTypedViewData()
    {
        return new NewViewData(this);
    }
    #endregion

#if UNITY_EDITOR

    [MenuItem("Assets/Create/KNTyArch/Asset/Models/NewDefinition")]
    static void CreateDefinition()
    {
        ModelAssetCreator.CreateModelAsset<NewDefinition>();
    }
#endif
}
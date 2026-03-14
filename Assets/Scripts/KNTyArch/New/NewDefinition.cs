using KNTyArch.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDefinition", menuName = "Definition/NewDefinition")]
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
}
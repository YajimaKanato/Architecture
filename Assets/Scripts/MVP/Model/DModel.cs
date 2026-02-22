using KNTy.MVP.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "DModel", menuName = "Models/DModel")]
public class DModel : ModelBase<DRuntimeModel>
{
    public override DRuntimeModel CreateTypedRuntimeModel()
    {
        return new DRuntimeModel(this);
    }
}
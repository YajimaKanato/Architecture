using KNTy.MVP.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "BModel", menuName = "Models/BModel")]
public class BModel : ModelBase<BRuntimeModel>
{
    public override BRuntimeModel CreateTypedRuntimeModel()
    {
        return new BRuntimeModel(this);
    }
}
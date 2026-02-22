using KNTy.MVP.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "EModel", menuName = "Models/EModel")]
public class EModel : ModelBase<ERuntimeModel>
{
    public override ERuntimeModel CreateTypedRuntimeModel()
    {
        return new ERuntimeModel(this);
    }
}
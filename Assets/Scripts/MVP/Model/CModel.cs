using KNTy.MVP.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "CModel", menuName = "Models/CModel")]
public class CModel : ModelBase<CRuntimeModel>
{
    public override CRuntimeModel CreateTypedRuntimeModel()
    {
        return new CRuntimeModel(this);
    }
}
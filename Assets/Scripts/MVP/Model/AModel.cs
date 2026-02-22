using KNTy.MVP.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "AModel", menuName = "Models/AModel")]
public class AModel : ModelBase<ARuntimeModel>
{
    public override ARuntimeModel CreateTypedRuntimeModel()
    {
        return new ARuntimeModel(this);
    }
}
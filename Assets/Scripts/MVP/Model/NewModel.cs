using KNTy.MVP.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "NewModel", menuName = "Models/NewModel")]
public class NewModel : ModelBase<NewRuntimeModel>
{
    public override NewRuntimeModel CreateTypedRuntimeModel()
    {
        return new NewRuntimeModel(this);
    }
}
using KNTy.MVP.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "NewModel", menuName = "Models/NewModel")]
public class NewModel : ModelBase<NewRuntimeModel>
{
    public override NewRuntimeModel CreateRuntimeModel()
    {
        return new NewRuntimeModel(this);
    }
}
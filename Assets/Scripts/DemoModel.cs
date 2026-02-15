using UnityEngine;

public class DemoModel : ModelBase<DemoRuntimeModel>
{
    public override DemoRuntimeModel CreateRuntimeModel()
    {
        return new DemoRuntimeModel(this);
    }
}

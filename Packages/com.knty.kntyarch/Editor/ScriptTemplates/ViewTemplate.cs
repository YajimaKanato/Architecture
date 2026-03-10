#if UNITY_EDITOR

using KNTyArch.Runtime;

namespace KNTyArch.Editor
{
    internal static class ViewTemplate
    {
        internal static string View(string name, string definitionName) =>
$@"using KNTyArch.Runtime;
using UnityEngine;

public class {name}View : ViewBase<{definitionName}Definition>
{{
    StateMachine<{name}View> _stateMachine = new();
    IState<{name}View>[] _stateCache;

    private void Start()
    {{
        
    }}

    private void Update()
    {{
        _stateMachine.Update();
    }}

    public override void Initialize()
    {{
        throw new System.NotImplementedException();
    }}

    public override void SetHandleID(int handleID)
    {{
        _definitionHandle = new ModelHandle<{definitionName}Definition>(handleID);
    }}

    public override void SubscribeEvent()
    {{
        throw new System.NotImplementedException();
    }}

    private void OnDestroy()
    {{
        EventHub.Unsubscribe(this);
    }}
}}";
    }
}
#endif
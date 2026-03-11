#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class InteractiveViewTemplate
    {
        internal static string InteractiveView(string className, string definitionName) =>
$@"using KNTyArch.Runtime;
using UnityEngine;

public class {className}InteractiveView : InteractiveViewBase<{definitionName}Definition>
{{
    StateMachine<{className}InteractiveView> _stateMachine = new();
    IState<{className}InteractiveView>[] _stateCache;

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

    public override void SubscribeEvent()
    {{
        throw new System.NotImplementedException();
    }}

    public override void UnsubscribeEvent()
    {{
        EventHub.Unsubscribe(this);
    }}
}}";
    }
}
#endif
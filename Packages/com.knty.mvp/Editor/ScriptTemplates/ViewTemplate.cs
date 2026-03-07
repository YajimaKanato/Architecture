#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class ViewTemplate
    {
        internal static string View(string name, string runtimeName) =>
$@"using KNTyArch.Runtime;
using UnityEngine;

public class {name}View : ViewBase<{runtimeName}Runtime>
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
}}";
    }
}
#endif
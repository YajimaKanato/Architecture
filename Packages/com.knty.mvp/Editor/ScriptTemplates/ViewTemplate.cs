#if UNITY_EDITOR

namespace KNTy.MVP.Editor
{
    internal static class ViewTemplate
    {
        internal static string View(string name) =>
$@"using KNTy.MVP.Runtime;
using UnityEngine;

public class {name}View : ViewBase
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

    public override void Initialize(ViewModelStorage storage, IEventHub eventHub)
    {{
        throw new System.NotImplementedException();
    }}
}}";
    }
}
#endif
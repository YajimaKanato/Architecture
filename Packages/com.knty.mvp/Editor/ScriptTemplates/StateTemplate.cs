#if UNITY_EDITOR
namespace KNTy.MVP.Editor
{
    internal static class StateTemplate
    {
        internal static string State(string className, string viewName) =>
$@"using KNTy.MVP.Runtime;
using System;

public class {className}State : IState<{viewName}View>
{{
    readonly {viewName}View _view;
    IDisposable _subscripotion;

    public {className}State({viewName}View view)
    {{
        _view = view;
    }}

    public bool CanExit(IState<{viewName}View> newState)
    {{
        throw new System.NotImplementedException();
    }}

    public void Enter()
    {{
        //_subscripotion = _view.EventHub.Subscribe<>();
    }}

    public void Execute()
    {{
        throw new System.NotImplementedException();
    }}

    public void Exit()
    {{
        _subscripotion?.Dispose();
    }}
}}";
    }
}
#endif
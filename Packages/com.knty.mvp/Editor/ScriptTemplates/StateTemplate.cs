#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class StateTemplate
    {
        internal static string State(string className, string viewName) =>
$@"using KNTyArch.Runtime;
using System;

public class {className}State : IState<{viewName}View>
{{
    readonly {viewName}View _view;
    readonly ViewModelStorage _storage;
    IDisposable _subscription;

    public {className}State({viewName}View view, ViewModelStorage storage)
    {{
        _view = view;
        _storage = storage;
    }}

    public bool CanExit(IState<{viewName}View> newState)
    {{
        throw new System.NotImplementedException();
    }}

    public void Enter()
    {{
        //_subscription = _view.EventHub.Subscribe<>();
    }}

    public void Execute()
    {{
        throw new System.NotImplementedException();
    }}

    public void Exit()
    {{
        _subscription?.Dispose();
    }}
}}";
    }
}
#endif
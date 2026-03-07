#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class StateTemplate
    {
        internal static string ViewState(string className, string viewName) =>
$@"using KNTyArch.Runtime;
using System;

public class {viewName}View{className}State : IState<{viewName}View>
{{
    readonly {viewName}View _view;
    IDisposable _subscription;

    public {viewName}View{className}State({viewName}View view)
    {{
        _view = view;
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

        internal static string InteractiveViewState(string className, string interactiveViewName) =>
$@"using KNTyArch.Runtime;
using System;

public class {interactiveViewName}IV{className}State : IState<{interactiveViewName}InteractiveView>
{{
    readonly {interactiveViewName}InteractiveView _view;
    IDisposable _subscription;

    public {interactiveViewName}IV{className}State({interactiveViewName}InteractiveView view)
    {{
        _view = view;
    }}

    public bool CanExit(IState<{interactiveViewName}InteractiveView> newState)
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
using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal static class StateTemplate
    {
        internal static string State(string name) =>
$@"using System;

public class DemoState : IState<DemoView>
{{
    readonly DemoView _view;
    IDisposable _subscripotion;

    public DemoState(DemoView view)
    {{
        _view = view;
    }}

    public bool CanExit(IState<ViewBase> newState)
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

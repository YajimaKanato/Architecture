using KNTy.MVP.Runtime;
using System;

public class NewState : IState<NewView>
{
    readonly NewView _view;
    IDisposable _subscripotion;

    public NewState(NewView view)
    {
        _view = view;
    }

    public bool CanExit(IState<NewView> newState)
    {
        throw new System.NotImplementedException();
    }

    public void Enter()
    {
        //_subscripotion = _view.EventHub.Subscribe<>();
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        _subscripotion?.Dispose();
    }
}
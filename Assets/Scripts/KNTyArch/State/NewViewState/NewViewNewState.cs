using KNTyArch.Runtime;
using System;

public class NewViewNewState : IState<NewView>
{
    readonly NewView _view;
    IDisposable _subscription;

    public NewViewNewState(NewView view)
    {
        _view = view;
    }

    public bool CanExit(IState<NewView> newState)
    {
        throw new System.NotImplementedException();
    }

    public void Enter()
    {
        //_subscription = _view.EventHub.Subscribe<>();
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        EventHub.Unsubscribe(this);
    }
}
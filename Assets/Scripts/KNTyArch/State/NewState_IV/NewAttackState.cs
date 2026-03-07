using KNTyArch.Runtime;
using System;

public class NewAttackState : IState<NewInteractiveView>
{
    readonly NewInteractiveView _view;
    IDisposable _subscription;

    public NewAttackState(NewInteractiveView view)
    {
        _view = view;
    }

    public bool CanExit(IState<NewInteractiveView> newState)
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
        _subscription?.Dispose();
    }
}
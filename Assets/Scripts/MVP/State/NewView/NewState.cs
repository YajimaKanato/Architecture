using KNTy.MVP.Runtime;
using System;

public class NewState : IState<NewView>
{
    readonly NewView _view;
    readonly ViewModelStorage _storage;
    IDisposable _subscripotion;

    public NewState(NewView view, ViewModelStorage storage)
    {
        _view = view;
        _storage = storage;
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
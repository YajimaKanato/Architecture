using KNTyArch.Runtime;
using UnityEngine;

public class NewInteractiveView : InteractiveViewBase
{
    StateMachine<NewInteractiveView> _stateMachine = new();
    IState<NewInteractiveView>[] _stateCache;
    NewPresenter _newPresenter;

    private void Start()
    {
            
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public override void BindPresenter(IPresenter presenter)
    {
        _newPresenter = (NewPresenter)presenter;
    }

    public override void SubscribeEvent()
    {
        throw new System.NotImplementedException();
    }

    public override void UnsubscribeEvent()
    {
        EventHub.Unsubscribe(this);
    }
}
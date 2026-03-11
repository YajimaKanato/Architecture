using KNTyArch.Runtime;
using UnityEngine;

public class NewView : ViewBase
{
    StateMachine<NewView> _stateMachine = new();
    IState<NewView>[] _stateCache;

    private void Start()
    {
        
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public override void Initialize()
    {
        throw new System.NotImplementedException();
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
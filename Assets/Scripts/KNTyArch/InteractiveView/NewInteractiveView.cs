using KNTyArch.Runtime;
using UnityEngine;

public class NewInteractiveView : InteractiveViewBase<NewDefinition>
{
    StateMachine<NewInteractiveView> _stateMachine = new();
    IState<NewInteractiveView>[] _stateCache;

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
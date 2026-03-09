using KNTyArch.Runtime;
using UnityEngine;

public class NewNewView : NewViewBase<NewDefinition>
{
    StateMachine<NewNewView> _stateMachine = new();
    IState<NewNewView>[] _stateCache;

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

    private void OnDestroy()
    {
        EventHub.Unsubscribe(this);
    }
}
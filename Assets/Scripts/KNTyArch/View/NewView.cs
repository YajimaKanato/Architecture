using KNTyArch.Runtime;
using UnityEngine;

public class NewView : ViewBase<NewDefinition>
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

    public override void SetHandleID(int handleID)
    {
        _definitionHandle = new ModelHandle<NewDefinition>(handleID);
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
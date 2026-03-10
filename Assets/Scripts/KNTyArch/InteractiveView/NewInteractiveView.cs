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
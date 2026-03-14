#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class InteractiveViewTemplate
    {
        internal static string InteractiveView(string className) =>
$@"using KNTyArch.Runtime;
using UnityEngine;

public class {className}InteractiveView : InteractiveViewBase
{{
    StateMachine<{className}InteractiveView> _stateMachine = new();
    IState<{className}InteractiveView>[] _stateCache;
    {className}Presenter _{className.ToLower()}Presenter;

    private void Start()
    {{
            
    }}

    private void Update()
    {{
        _stateMachine.Update();
    }}

    public override void BindPresenter(IPresenter presenter)
    {{
        _{className.ToLower()}Presenter = ({className}Presenter)presenter;
    }}

    public override void SubscribeEvent()
    {{
        throw new System.NotImplementedException();
    }}

    public override void UnsubscribeEvent()
    {{
        EventHub.Unsubscribe(this);
    }}
}}";
    }
}
#endif
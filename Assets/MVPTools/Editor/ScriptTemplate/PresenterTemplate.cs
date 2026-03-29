#if UNITY_EDITOR
namespace MVPTools.Editor
{
    internal static class PresenterTemplate
    {
        internal static string Presenter(string name) =>
$@"using MVPTools.Runtime;
using UnityEngine;

public class {name}Presenter : ISubscribable
{{
    {name}View _view;
    {name}Runtime _runtime;
    bool _subscribed;

    public {name}Presenter({name}View view, {name}Model model)
    {{
        _view = view;
        _runtime = model.CreateRuntime();
    }}

    public void Dispose()
    {{
        _runtime?.Dispose();
        _runtime = null;
        Unsubscribe();
    }}

    public void Subscribe()
    {{
        if (_subscribed) return;
        _subscribed = true;
        //EventBus.Subscribe<>(this,);
    }}

    public void Unsubscribe()
    {{
        if (!_subscribed) return;
        _subscribed = false;
        EventBus.Unsubscribe(this);
    }}
}}";
    }
}
#endif
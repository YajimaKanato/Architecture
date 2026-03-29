#if UNITY_EDITOR
namespace MVPTools.Editor
{
    internal static class ViewCoreTemplate
    {
        internal static string ViewCore(string name) =>
$@"using MVPTools.Runtime;
using UnityEngine;

public partial class {name}View : ViewBase
{{
    [SerializeField] {name}Model _model;
    {name}Presenter _presenter;

    public override void Initialize()
    {{
        _presenter = new {name}Presenter(this, _model);
        _presenter?.Subscribe();
    }}

    private void OnEnable()
    {{
        _presenter?.Subscribe();
    }}

    private void OnDisable()
    {{
        _presenter?.Unsubscribe();
    }}

    private void OnDestroy()
    {{
        _presenter?.Dispose();
        _presenter = null;
    }}
}}
";
    }
}
#endif
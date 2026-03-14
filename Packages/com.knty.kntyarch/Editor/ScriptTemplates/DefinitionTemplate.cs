#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class DefinitionTemplate
    {
        internal static string Definition(string name) =>
$@"using KNTyArch.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = ""{name}Definition"", menuName = ""Definition/{name}Definition"")]
public class {name}Definition : DefinitionBase<{name}Runtime, {name}ViewData>
{{

    #region Non-Edit
    public override {name}Runtime CreateTypedRuntime()
    {{
        return new {name}Runtime(this);
    }}

    public override {name}ViewData CreateTypedViewData()
    {{
        return new {name}ViewData(this);
    }}
    #endregion
}}";
    }
}
#endif
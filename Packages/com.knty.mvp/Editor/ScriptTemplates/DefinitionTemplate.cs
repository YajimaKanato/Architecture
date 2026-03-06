#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class DefinitionTemplate
    {
        internal static string Definition(string name) =>
$@"#if UNITY_EDITOR
using UnityEditor;
#endif
using KNTyArch.Runtime;
using UnityEngine;

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

#if UNITY_EDITOR

    [MenuItem(""Assets/Create/KNTyArch/Asset/Models/{name}Definition"")]
    static void CreateDefinition()
    {{
        ModelAssetCreator.CreateModelAsset<{name}Definition>();
    }}
#endif
}}";
    }
}
#endif
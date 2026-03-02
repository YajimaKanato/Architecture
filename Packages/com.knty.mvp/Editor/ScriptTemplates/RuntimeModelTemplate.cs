#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class RuntimeModelTemplate
    {
        internal static string RuntimeModel(string name) =>
$@"using KNTyArch.Runtime;

public class {name}RuntimeModel : RuntimeModelBase
{{
    public {name}RuntimeModel({name}Model model)
    {{

    }}

    public override void Dispose()
    {{

    }}
}}";
    }
}
#endif
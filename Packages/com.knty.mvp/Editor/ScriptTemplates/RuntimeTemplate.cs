#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class RuntimeTemplate
    {
        internal static string Runtime(string name) =>
$@"using KNTyArch.Runtime;

public class {name}Runtime : RuntimeBase
{{
    public {name}Runtime({name}Definition definition)
    {{

    }}

    public override void Dispose()
    {{

    }}
}}";
    }
}
#endif
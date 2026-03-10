#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class ViewDataTemplate
    {
        internal static string ViewData(string className) =>
$@"using KNTyArch.Runtime;

public class {className}ViewData : ViewDataBase
{{
    public {className}ViewData({className}Runtime runtime)
    {{

    }}

    public override void Dispose()
    {{

    }}
}}";
    }
}
#endif
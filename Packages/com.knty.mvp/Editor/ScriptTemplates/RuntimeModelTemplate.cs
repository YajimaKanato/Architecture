#if UNITY_EDITOR

namespace KNTy.MVP.Editor
{
    internal static class RuntimeModelTemplate
    {
        public static string RuntimeModel(string name) =>
$@"using KNTy.MVP.Runtime;

public class {name}RuntimeModel : RuntimeModelBase
{{
    public override string DebugLabel => GetType().Name;

    public {name}RuntimeModel({name}Model model)
    {{

    }}

    public override void Initialize()
    {{

    }}

    public override void Dispose()
    {{

    }}
}}";
    }
}
#endif
using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal static class RuntimeModelTemplate
    {
        public static string RuntimeModel(string name) =>
$@"using KNTy.MVP.Runtime;

public class {name}RuntimeModel : IRuntimeModel
{{
    public {name}RuntimeModel({name}Model model)
    {{

    }}

    public void Initialize()
    {{

    }}

    public void Dispose()
    {{

    }}
}}";
    }
}

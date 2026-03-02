#if UNITY_EDITOR

namespace KNTy.MVP.Editor
{
    internal static class InputTemplate
    {
        internal static string Input(string className,string runtimeModelName) =>
$@"using KNTy.MVP.Runtime;
using UnityEngine;

public class {className}Input : InputBase<{runtimeModelName}RuntimeModel>
{{
    private void Start()
    {{
            
    }}

    private void Update()
    {{
            
    }}
}}";
    }
}
#endif
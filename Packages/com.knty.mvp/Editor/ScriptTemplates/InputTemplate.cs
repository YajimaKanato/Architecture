#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class InputTemplate
    {
        internal static string Input(string className, string runtimeName) =>
$@"using KNTyArch.Runtime;
using UnityEngine;

public class {className}Input : InputBase<{runtimeName}Runtime>
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
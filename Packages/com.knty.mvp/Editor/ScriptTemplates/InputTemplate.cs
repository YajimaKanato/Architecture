#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class InputTemplate
    {
        internal static string Input(string className, string runtimeModelName) =>
$@"using KNTyArch.Runtime;
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
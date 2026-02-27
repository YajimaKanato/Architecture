#if UNITY_EDITOR

namespace KNTy.MVP.Editor
{
    internal static class InputTemplate
    {
        internal static string Input(string className) =>
$@"using KNTy.MVP.Runtime;
using UnityEngine;

public class {className}Input : InputBase
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
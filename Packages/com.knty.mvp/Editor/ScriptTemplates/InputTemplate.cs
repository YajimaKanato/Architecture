#if UNITY_EDITOR

namespace KNTy.MVP.Editor
{
    internal static class InputTemplate
    {
        internal static string Input(string className, string presenterName) =>
$@"using KNTy.MVP.Runtime;
using UnityEngine;

public class {className}Input : InputBase<{presenterName}Presenter>
{{
    public override void Initialize()
    {{
        throw new System.NotImplementedException();
    }}

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
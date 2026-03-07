#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class InteractiveViewTemplate
    {
        internal static string InteractiveView(string className, string runtimeName) =>
$@"using KNTyArch.Runtime;
using UnityEngine;

public class {className}InteractiveView : InteractiveViewBase<{runtimeName}Runtime>
{{
    private void Start()
    {{
            
    }}

    private void Update()
    {{
            
    }}

    public override void SubscribeEvent()
    {{
        throw new System.NotImplementedException();
    }}
}}";
    }
}
#endif
using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal static class ViewTemplate
    {
        public static string View(string name) =>
$@"using KNTy.MVP.Runtime;
using UnityEngine;

public class {name}View : ViewBase
{{
    public override void Initialize()
    {{

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

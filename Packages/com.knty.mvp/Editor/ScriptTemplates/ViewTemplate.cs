namespace KNTy.MVP.Editor
{
    internal static class ViewTemplate
    {
        public static string View(string name) =>
$@"using KNTy.MVP.Runtime;
using UnityEngine;

public class {name}View : ViewBase<{name}Presenter>
{{
    private void Start()
    {{
        
    }}

    private void Update()
    {{
        
    }}

    public override void Initialize()
    {{

    }}
}}";
    }
}

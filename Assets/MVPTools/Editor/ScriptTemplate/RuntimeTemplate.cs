#if UNITY_EDITOR
namespace MVPTools.Editor
{
    internal static class RuntimeTemplate
    {
        internal static string Runtime(string name) =>
$@"using MVPTools.Runtime;

public class {name}Runtime : IRuntime
{{
        public {name}Runtime({name}Model model)
        {{
            
        }}

        public void Dispose()
        {{
            
        }}
}}";
    }
}
#endif
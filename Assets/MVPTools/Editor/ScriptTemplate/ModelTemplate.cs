#if UNITY_EDITOR
namespace MVPTools.Editor
{
    internal static class ModelTemplate
    {
        internal static string Model(string name) =>
$@"using MVPTools.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = ""{name}Model"", menuName = ""Model/{name}Model"")]
public class {name}Model : ScriptableObject, IModel<{name}Runtime>
{{
    public {name}Runtime CreateRuntime()
    {{
        return new {name}Runtime(this);
    }}
}}";
    }
}
#endif
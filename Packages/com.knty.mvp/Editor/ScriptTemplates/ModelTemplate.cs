#if UNITY_EDITOR

namespace KNTy.MVP.Editor
{
    internal static class ModelTemplate
    {
        internal static string Model(string name) =>
$@"using KNTy.MVP.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = ""{name}Model"", menuName = ""Models/{name}Model"")]
public class {name}Model : ModelBase<{name}RuntimeModel>
{{
    public override {name}RuntimeModel CreateTypedRuntimeModel()
    {{
        return new {name}RuntimeModel(this);
    }}
}}";
    }
}
#endif
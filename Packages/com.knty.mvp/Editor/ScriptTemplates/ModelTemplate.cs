#if UNITY_EDITOR

namespace KNTy.MVP.Editor
{
    internal static class ModelTemplate
    {
        internal static string Model(string name) =>
$@"using KNTy.MVP.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = ""{name}Model"", menuName = ""MVP/ModelAsset/{name}Model"")]
public class {name}Model : ModelBase<{name}RuntimeModel, {name}ViewModel>
{{
    public override {name}RuntimeModel CreateTypedRuntimeModel()
    {{
        return new {name}RuntimeModel(this);
    }}

    public override {name}ViewModel CreateTypedViewModel()
    {{
        return new {name}ViewModel(this);
    }}
}}";
    }
}
#endif
using UnityEngine;

namespace KNTyArch.Editor
{
    internal static class ObjectFactoryTemplate
    {
        internal static string ObjectFactory(string name) =>
$@"using KNTyArch.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = ""{name}Factory"", menuName = ""Factory/{name}Factory"")]
public class {name}Factory : SceneObjectFactoryBase
{{
    [SerializeField] {name}Definition _{name.ToLower()}Definition;
    [SerializeField] {name}InteractiveView _{name.ToLower()}IV;

    public override InteractiveViewBase CreateSceneObject()
    {{
        var p = new {name}Presenter(_{name.ToLower()}IV, _{name.ToLower()}Definition);
        return _{name.ToLower()}IV;
    }}

    public override InteractiveViewBase CreateSceneObject(int id)
    {{
        _id = id;
        var p = new {name}Presenter(_{name.ToLower()}IV, _{name.ToLower()}Definition);
        return _{name.ToLower()}IV;
    }}
}}";
    }
}

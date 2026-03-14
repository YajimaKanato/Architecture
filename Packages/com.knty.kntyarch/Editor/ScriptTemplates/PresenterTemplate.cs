#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class PresenterTemplate
    {
        internal static string Presenter(string name) =>
$@"using KNTyArch.Runtime;
using System;

public class {name}Presenter : IPresenter
{{
    {name}InteractiveView _{name.ToLower()}IV;
    {name}Runtime _{name.ToLower()}Runtime;

    public {name}Presenter({name}InteractiveView {name.ToLower()}IV, {name}Definition {name.ToLower()}Definition)
    {{
        _{name.ToLower()}IV = {name.ToLower()}IV;
        _{name.ToLower()}Runtime = ({name}Runtime){name.ToLower()}Definition.CreateRuntime();
        _{name.ToLower()}IV.BindPresenter(this);
    }}
}}";
    }
}
#endif
#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class ViewModelTemplate
    {
        internal static string ViewModel(string className) =>
$@"using KNTyArch.Runtime;

public class {className}ViewModel : ViewModelBase
{{
    public {className}ViewModel({className}Model model)
    {{

    }}

    public override void Dispose()
    {{

    }}
}}";
    }
}
#endif
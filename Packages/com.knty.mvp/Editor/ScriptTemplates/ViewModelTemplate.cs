using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal static class ViewModelTemplate
    {
        internal static string ViewModel(string className) =>
$@"using KNTy.MVP.Runtime;

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

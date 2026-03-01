using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal static class ViewModelTemplate
    {
        internal static string ViewModel(string className) =>
$@"using KNTy.MVP.Runtime;

public readonly struct {className}ViewModel : IViewModel
{{
    public {className}ViewModel({className}Model model)
    {{

    }}
}}";
    }
}

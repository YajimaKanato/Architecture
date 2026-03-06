#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class PresenterFactoryTemplate
    {
        internal static string PresenterFactory(string className) =>
$@"using KNTyArch.Runtime;
using System.Collections.Generic;

public class {className}ScenePresenterFactory : IPresenterFactory
{{
    readonly List<PresenterBase> _presenters = new();

    public void GeneratePresenter()
    {{
        foreach (var presenter in _presenters)
        {{
            presenter.Initialize();
        }}
    }}

    public void Dispose()
    {{
        foreach(var  presenter in _presenters)
        {{
            presenter.Dispose();
        }}
    }}
}}";
    }
}
#endif
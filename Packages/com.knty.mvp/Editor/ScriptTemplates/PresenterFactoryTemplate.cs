using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal static class PresenterFactoryTemplate
    {
        internal static string PresenterFactory(string className) =>
$@"using KNTy.MVP.Runtime;
using System.Collections.Generic;

public class DemoScenePresenterFactory : IPresenterFactory
{{
    readonly List<PresenterBase> _presenters = new();

    public void GeneratePresenter(RuntimeModelStorage storage_RM, ViewModelStorage storage_VM, IEventHub inputHub, IEventHub eventHub)
    {{
        foreach (var presenter in _presenters)
        {{
            presenter.Initialize(storage_RM, storage_VM, inputHub, eventHub);
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

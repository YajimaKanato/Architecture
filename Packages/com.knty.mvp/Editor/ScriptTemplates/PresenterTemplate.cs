#if UNITY_EDITOR

namespace KNTy.MVP.Editor
{
    internal static class PresenterTemplate
    {
        internal static string Presenter(string name) =>
$@"using KNTy.MVP.Runtime;
using System;

public class DemoPresenter : PresenterBase
{{
    public DemoPresenter(IEventHub eventHub) : base(eventHub)
    {{

    }}

    public override void Dispose()
    {{
        {{
            throw new NotImplementedException();
        }}
    }}

    public override void Initialize()
    {{
        {{
            throw new NotImplementedException();
        }}
    }}
}}";
    }
}
#endif
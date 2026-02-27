#if UNITY_EDITOR

namespace KNTy.MVP.Editor
{
    internal static class PresenterTemplate
    {
        internal static string Presenter(string name) =>
$@"using KNTy.MVP.Runtime;
using System;

public class {name}Presenter : PresenterBase
{{
    public {name}Presenter(RuntimeModelStorage storage_RM, ViewModelStorage storage_VM, IEventHub inputHub, IEventHub eventHub) : 
        base(storage_RM, storage_VM, inputHub, eventHub)
    {{

    }}

    public override void Dispose()
    {{
        throw new NotImplementedException();
    }}

    protected override void SubscribeInputHub()
    {{
        throw new NotImplementedException();
    }}
}}";
    }
}
#endif
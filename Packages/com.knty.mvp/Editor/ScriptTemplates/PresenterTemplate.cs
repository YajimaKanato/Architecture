#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class PresenterTemplate
    {
        internal static string Presenter(string name) =>
$@"using KNTyArch.Runtime;
using System;

public class {name}Presenter : PresenterBase
{{
    public override void Initialize(RuntimeModelStorage storage_RM, ViewModelStorage storage_VM, IEventHub inputHub, IEventHub eventHub)
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
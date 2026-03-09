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
    public override void Initialize()
    {{
        throw new NotImplementedException();
    }}

    public override void Dispose()
    {{
        throw new NotImplementedException();
    }}

    protected override void SubscribeEvent()
    {{
        throw new NotImplementedException();
    }}

    protected override void UnsubscribeEvent()
    {{
        EventHub.Unsubscribe(this);
    }}
}}";
    }
}
#endif
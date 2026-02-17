using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal static class PresenterTemplate
    {
        public static string Presenter(string name) =>
$@"using KNTy.MVP.Runtime;

public class {name}Presenter : PresenterBase<{name}View>
{{
    public {name}Presenter({name}View view) : base(view)
    {{

    }}

    public override void Initialize()
    {{

    }}

    protected override void Bind()
    {{

    }}

    protected override void Unbind()
    {{

    }}

    public override void Dispose()
    {{
        base.Dispose();
    }}
}}";
    }
}

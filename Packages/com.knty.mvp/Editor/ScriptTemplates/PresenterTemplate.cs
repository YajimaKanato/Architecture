namespace KNTy.MVP.Editor
{
    internal static class PresenterTemplate
    {
        public static string Presenter(string name) =>
$@"using KNTy.MVP.Runtime;

public class {name}Presenter : PresenterBase<{name}View>
{{
    public override string DebugLabel => GetType().Name;

    public {name}Presenter({name}View view) : base(view)
    {{

    }}

    public override void Initialize()
    {{

    }}

    public override void Dispose()
    {{
        
    }}

    protected override void Bind()
    {{

    }}

    protected override void Unbind()
    {{

    }}
}}";
    }
}

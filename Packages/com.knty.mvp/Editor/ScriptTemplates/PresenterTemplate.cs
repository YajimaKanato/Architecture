namespace KNTy.MVP.Editor
{
    internal static class PresenterTemplate
    {
        public static string PresenterCore(string name) =>
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

        public static string PartialPresenter(string className, string modelName) =>
$@"public partial class {className}Presenter
{{
    {modelName}RuntimeModel _{modelName.ToLower()}RuntimeModel;
    public {modelName}RuntimeModel {modelName}RuntimeModel => _{modelName.ToLower()}RuntimeModel;
}}";
    }
}

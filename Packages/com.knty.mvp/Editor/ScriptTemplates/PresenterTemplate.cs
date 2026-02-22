namespace KNTy.MVP.Editor
{
    internal static class PresenterTemplate
    {
        internal static string PresenterCore(string name, string argument, string variable, string assignment) =>
$@"using KNTy.MVP.Runtime;

public partial class {name}Presenter : PresenterBase<{name}View>
{{
{variable}

    public {name}Presenter({argument})
    {{
{assignment}
    }}
}}";

        internal static string PresenterLifeCycle(string className) =>
$@"using KNTy.MVP.Runtime;

public partial class {className}Presenter : PresenterBase<{className}View>
{{
    public override void Initialize()
    {{

    }}

    public override void Dispose()
    {{

    }}

    protected override void Bind({className}View view)
    {{

    }}

    protected override void Unbind()
    {{

    }}
}}";

        internal static string PartialPresenter(string className, string modelName) =>
$@"public partial class {className}Presenter
{{
    {modelName}RuntimeModel _{modelName.ToLower()}RuntimeModel;
    public {modelName}RuntimeModel {modelName}RuntimeModel => _{modelName.ToLower()}RuntimeModel;
}}";
    }
}

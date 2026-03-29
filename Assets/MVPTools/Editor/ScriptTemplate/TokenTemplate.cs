#if UNITY_EDITOR
namespace MVPTools.Editor
{
    internal static class TokenTemplate
    {
        internal static string Token(string name) =>
$@"using MVPTools.Runtime;

public readonly struct {name}Token : IToken
{{
    //public readonly 

    public {name}Token()
    {{

    }}
}}";
    }
}
#endif
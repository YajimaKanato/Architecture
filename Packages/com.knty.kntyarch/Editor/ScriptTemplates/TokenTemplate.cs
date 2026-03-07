using UnityEngine;

namespace KNTyArch.Editor
{
    internal static class TokenTemplate
    {
        internal static string Token(string className) =>
$@"using KNTyArch.Runtime;

public readonly struct {className}Token : IToken
{{
    public readonly string ID;

    public {className}Token(string id)
    {{
        ID = id;
    }}
}}";
    }
}

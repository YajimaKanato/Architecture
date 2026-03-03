using UnityEngine;

namespace KNTyArch.Editor
{
    internal static class TokenTemplate
    {
        internal static string Token(string className) =>
$@"using KNTyArch.Runtime;

public class DemoToken : IToken
{{
    public ID ID => throw new System.NotImplementedException();

    public DemoToken(ID id)
    {{

    }}
}}";
    }
}

#if UNITY_EDITOR
namespace MVPTools.Editor
{
    internal static class InputTemplate
    {
        internal static string Input(string name) =>
$@"using MVPTools.Runtime;
using UnityEngine;

public partial class {name}View
{{
    //必要な場合にViewの入力部分を実装
}}";
    }
}
#endif
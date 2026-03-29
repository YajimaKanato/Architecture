#if UNITY_EDITOR
namespace MVPTools.Editor
{
    internal static class ViewTemplate
    {
        internal static string View(string name) =>
$@"using MVPTools.Runtime;
using UnityEngine;

public partial class {name}View
{{
    //Viewの表示部分を実装
}}";
    }
}
#endif
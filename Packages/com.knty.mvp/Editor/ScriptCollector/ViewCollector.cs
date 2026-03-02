#if UNITY_EDITOR
using KNTyArch.Runtime;
using System.Collections.Generic;
using UnityEditor;

namespace KNTyArch.Editor
{
    internal static partial class ScriptCollection
    {
        static List<string> _viewNames = new();

        internal static IReadOnlyList<string> ViewNames => _viewNames;

        [InitializeOnLoadMethod]
        internal static void CollectView()
        {
            _viewNames.Clear();
            var guids = AssetDatabase.FindAssets("t:MonoScript", new string[] { "Assets/Scripts/KNTyArch/View" });

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
                var type = mono?.GetClass();
                if (type == null) continue;
                if (typeof(ViewBase).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                {
                    _viewNames.Add(type.Name);
                }
            }
        }
    }
}
#endif
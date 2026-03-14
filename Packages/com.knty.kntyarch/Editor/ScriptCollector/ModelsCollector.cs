#if UNITY_EDITOR
using KNTyArch.Runtime;
using System.Collections.Generic;
using UnityEditor;

namespace KNTyArch.Editor
{
    internal static partial class ScriptCollection
    {
        static List<string> _definitionNames = new();
        static List<string> _runtimeNames = new();

        internal static IReadOnlyList<string> DefinitionNames => _definitionNames;
        internal static IReadOnlyList<string> RuntimeNames => _runtimeNames;

        //[InitializeOnLoadMethod]
        internal static void CollectDefinitions()
        {
            _definitionNames.Clear();
            var guids = AssetDatabase.FindAssets("t:MonoScript", new string[] { "Assets/Scripts/KNTyArch/Models/Definition" });

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
                var type = mono?.GetClass();
                if (type == null) continue;

                if (typeof(DefinitionBase).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                {
                    _definitionNames.Add(type.Name);
                }
            }
        }

        //[InitializeOnLoadMethod]
        internal static void CollectRuntimes()
        {
            _runtimeNames.Clear();
            var guids = AssetDatabase.FindAssets("t:MonoScript", new string[] { "Assets/Scripts/KNTyArch/Models/Runtime" });

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
                var type = mono?.GetClass();
                if (type == null) continue;

                if (typeof(RuntimeBase).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                {
                    _runtimeNames.Add(type.Name);
                }
            }
        }
    }
}
#endif
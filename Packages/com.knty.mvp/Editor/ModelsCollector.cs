#if UNITY_EDITOR
using KNTy.MVP.Runtime;
using System.Collections.Generic;
using UnityEditor;

namespace KNTy.MVP.Editor
{
    internal static partial class ScriptCollection
    {
        static List<string> _modelNames = new();
        static List<string> _runtimeModelNames = new();

        internal static IReadOnlyList<string> ModelNames => _modelNames;
        internal static IReadOnlyList<string> RuntimeModelNames => _runtimeModelNames;

        [InitializeOnLoadMethod]
        internal static void CollectModels()
        {
            _modelNames.Clear();
            var guids = AssetDatabase.FindAssets("t:MonoScript", new string[] { "Assets/Scripts/MVP/Model" });

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
                var type = mono?.GetClass();
                if (type == null) continue;

                if (typeof(ModelBase).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                {
                    _modelNames.Add(type.Name);
                }
            }
        }

        [InitializeOnLoadMethod]
        internal static void CollectRuntimeModels()
        {
            _runtimeModelNames.Clear();
            var guids = AssetDatabase.FindAssets("t:MonoScript", new string[] { "Assets/Scripts/MVP/RuntimeModel" });

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
                var type = mono?.GetClass();
                if (type == null) continue;

                if (typeof(RuntimeModelBase).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                {
                    _runtimeModelNames.Add(type.Name);
                }
            }
        }
    }
}
#endif
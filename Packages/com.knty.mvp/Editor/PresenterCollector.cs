using KNTy.MVP.Runtime;
using System.Collections.Generic;
using UnityEditor;

namespace KNTy.MVP.Editor
{
    internal static partial class ScriptCollection
    {
        static List<string> _presenterNames = new();

        internal static IReadOnlyList<string> PresenterNames => _presenterNames;

        [InitializeOnLoadMethod]
        internal static void CollectPresenter()
        {
            _presenterNames.Clear();
            var guids = AssetDatabase.FindAssets("t:MonoScript", new string[] { "Assets/Scripts/MVP/Presenter" });

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
                var type = mono?.GetClass();
                if (type == null) continue;

                if (typeof(PresenterBase).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                {
                    _presenterNames.Add(type.Name);
                }
            }
        }
    }
}

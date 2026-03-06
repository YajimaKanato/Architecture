#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using KNTyArch.Runtime;
using System.Linq;

namespace KNTyArch.Editor
{
    internal static class DefinitionCollectionCreator
    {
        [MenuItem("KNTyArch/Create/Asset/DefinitionCollection")]
        [MenuItem("Assets/Create/KNTyArch/Asset/DefinitionCollection")]
        static void Create()
        {
            var collection = ScriptableObject.CreateInstance<DefinitionCollection>();

            var guids = AssetDatabase.FindAssets("t:DefinitionBase", new string[] { "Assets/DefinitionAssets" });

            var definitions = guids
                .Select(g =>
                {
                    var path = AssetDatabase.GUIDToAssetPath(g);
                    return AssetDatabase.LoadAssetAtPath<DefinitionBase>(path);
                })
                .Where(m => !m.GetType().IsAbstract)
                .ToArray();

            collection.SetModels(definitions);

            AssetDatabase.CreateAsset(collection, "Assets/DefinitionCollection.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = collection;
            Debug.Log($"Create \"DefinitionCollection.asset\" under \"Assets\"", collection);
        }
    }
}
#endif
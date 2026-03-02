#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using KNTyArch.Runtime;
using System.Linq;

namespace KNTyArch.Editor
{
    internal static class ModelCollectionCreator
    {
        [MenuItem("KNTyArch/Create/Asset/ModelCollection")]
        [MenuItem("Assets/Create/KNTyArch/Asset/ModelCollection")]
        static void Create()
        {
            var collection = ScriptableObject.CreateInstance<ModelCollection>();

            var guids = AssetDatabase.FindAssets("t:ModelBase", new string[] { "Assets/ModelAssets" });

            var models = guids
                .Select(g =>
                {
                    var path = AssetDatabase.GUIDToAssetPath(g);
                    return AssetDatabase.LoadAssetAtPath<ModelBase>(path);
                })
                .Where(m => !m.GetType().IsAbstract)
                .ToArray();

            collection.SetModels(models);

            AssetDatabase.CreateAsset(collection, "Assets/ModelCollection.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = collection;
            Debug.Log($"Create \"ModelCollection.asset\" under \"Assets\"", collection);
        }
    }
}
#endif
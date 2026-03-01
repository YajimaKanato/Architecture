#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using KNTy.MVP.Runtime;
using System.Linq;

namespace KNTy.MVP.Editor
{
    internal static class ModelCollectionCreator
    {
        [MenuItem("MVP/Create/Asset/ModelCollection")]
        [MenuItem("Assets/Create/MVP/Asset/ModelCollection")]
        static void Create()
        {
            var collection = ScriptableObject.CreateInstance<ModelCollection>();

            var guids = AssetDatabase.FindAssets("t:ModelBase", new string[] { "Assets/Scripts/MVP/Models/Model" });

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
        }
    }
}
#endif
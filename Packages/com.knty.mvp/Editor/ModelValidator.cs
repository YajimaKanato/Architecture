#if UNITY_EDITOR
using UnityEditor;
using KNTy.MVP.Runtime;
using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal class ModelValidator : AssetPostprocessor
    {
        const string FULLPATH = "Assets/ModelAssets";

        private static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            var isInvalidPath = false;
            foreach (var path in movedAssets)
            {
                var asset = AssetDatabase.LoadAssetAtPath<ModelBase>(path);
                if (asset == null) continue;

                if (path.StartsWith(FULLPATH)) continue;

                EnsureFolderExists(FULLPATH);
                isInvalidPath = true;
            }
            if (isInvalidPath) Debug.LogWarning($"Please create \"Model.asset\" in Assets/ModelAssets");
        }

        static void EnsureFolderExists(string fullPath)
        {
            if (AssetDatabase.IsValidFolder(fullPath)) return;

            var parts = fullPath.Split('/');
            string current = parts[0];

            for (int i = 1; i < parts.Length; i++)
            {
                string next = $"{current}/{parts[i]}";
                if (!AssetDatabase.IsValidFolder(next))
                {
                    AssetDatabase.CreateFolder(current, parts[i]);
                }
                current = next;
            }
        }
    }
}
#endif
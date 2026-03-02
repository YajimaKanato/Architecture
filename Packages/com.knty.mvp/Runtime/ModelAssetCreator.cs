using UnityEditor;
using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public static class ModelAssetCreator
    {
        public static void CreateModelAsset<T>() where T : ModelBase
        {
            var model = ScriptableObject.CreateInstance<T>();
            EnsureFolderExists();
            AssetDatabase.CreateAsset(model, AssetDatabase.GenerateUniqueAssetPath($"Assets/ModelAssets/{typeof(T).Name}.asset"));
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = model;
            Debug.Log($"Create \"{typeof(T).Name}.asset\" under \"Assets/ModelAssets\"", model);
        }

        static void EnsureFolderExists()
        {
            var fullPath = "Assets/ModelAssets";

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

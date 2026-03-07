using UnityEditor;
using UnityEngine;

namespace KNTyArch.Runtime
{
    public static class DefinitionAssetCreator
    {
        public static void CreateModelAsset<T>() where T : DefinitionBase
        {
            var definition = ScriptableObject.CreateInstance<T>();
            EnsureFolderExists();
            AssetDatabase.CreateAsset(definition, AssetDatabase.GenerateUniqueAssetPath($"Assets/DefinitionAssets/{typeof(T).Name}.asset"));
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = definition;
            Debug.Log($"Create \"{typeof(T).Name}.asset\" under \"Assets/DefinitionAssets\"", definition);
        }

        static void EnsureFolderExists()
        {
            var fullPath = "Assets/DefinitionAssets";

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

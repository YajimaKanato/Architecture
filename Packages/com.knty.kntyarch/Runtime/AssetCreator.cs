using UnityEditor;
using UnityEngine;

namespace KNTyArch.Runtime
{
    public static class AssetCreator
    {
        public static void CreateModelAsset<T>() where T : DefinitionBase
        {
            var definition = ScriptableObject.CreateInstance<T>();
            EnsureFolderExists("Assets/DefinitionAssets");
            AssetDatabase.CreateAsset(definition, AssetDatabase.GenerateUniqueAssetPath($"Assets/DefinitionAssets/{typeof(T).Name}.asset"));
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = definition;
            Debug.Log($"Create \"{typeof(T).Name}.asset\" under \"Assets/DefinitionAssets\"", definition);
        }

        public static void CreateFactoryAsset<T>() where T : SceneObjectFactoryBase
        {
            var factory = ScriptableObject.CreateInstance<T>();
            EnsureFolderExists("Assets/Factory");
            AssetDatabase.CreateAsset(factory, AssetDatabase.GenerateUniqueAssetPath($"Assets/Factory/{typeof(T).Name}.asset"));
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = factory;
            Debug.Log($"Create \"{typeof(T).Name}.asset\" under \"Assets/DefinitionAssets\"", factory);
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

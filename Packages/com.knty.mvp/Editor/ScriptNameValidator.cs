#if UNITY_EDITOR
using UnityEditor;

namespace KNTy.MVP.Editor
{
    internal class ScriptNameValidator : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetsPath)
        {
            foreach (var path in importedAssets)
            {
                NameValidate(path);
            }

            foreach (var path in movedAssets)
            {
                NameValidate(path);
            }
        }

        static void NameValidate(string path)
        {
            if (!path.EndsWith(".cs")) return;
            var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
            ScriptNameValidatorCore.Validate(mono);
        }
    }
}
#endif
#if UNITY_EDITOR
using UnityEditor;

namespace KNTy.MVP.Editor
{
    internal class ScriptValidator : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetsPath)
        {
            foreach (var path in importedAssets)
            {
                ScriptNameValidator.NameValidate(path);
            }

            foreach (var path in movedAssets)
            {
                ScriptNameValidator.NameValidate(path);
            }

            //ScriptCollection.CollectModels();
            //ScriptCollection.CollectRuntimeModels();
            //ScriptCollection.CollectPresenter();
            ScriptCollection.CollectView();
        }
    }
}
#endif
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal class ScriptNamingValidation
    {
        [MenuItem("MVP/Validation/Script Naming Validation")]
        static void ScriptNamingValidator()
        {
            var guids = AssetDatabase.FindAssets("t:MonoScript");
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(path);

                ScriptNameValidatorCore.Validate(mono);
            }
            Debug.Log("Script Naming Validation Finished");
        }
    }
}
#endif
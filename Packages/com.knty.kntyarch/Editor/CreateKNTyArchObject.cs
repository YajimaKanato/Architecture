#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using KNTyArch.Runtime;

namespace KNTyArch.Editor
{
    internal static class CreateKNTyArchObject
    {
        //[MenuItem("KNTyArch/Create/GameObject/KNTyArch Manager")]
        //[MenuItem("GameObject/KNTyArch/KNTyArch Manager")]
        static void CreateKNTyArchManager(MenuCommand command)
        {
            if (Object.FindAnyObjectByType<KNTyArchManager>() != null)
            {
                EditorUtility.DisplayDialog(
                    "Already Exists",
                    "MVPManager already exists in the scene.",
                    "OK");
                return;
            }

            var go = new GameObject("KNTyArch Manager");
            go.AddComponent<KNTyArchManager>();

            GameObjectUtility.SetParentAndAlign(go, command.context as GameObject);
            Undo.RegisterCreatedObjectUndo(go, "Create KNTyArch Manager");
            Selection.activeObject = go;
        }
    }
}
#endif
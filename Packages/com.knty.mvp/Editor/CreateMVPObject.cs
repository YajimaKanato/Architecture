#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using KNTy.MVP.Runtime;

namespace KNTy.MVP.Editor
{
    internal static class CreateMVPObject// : EditorWindow
    {
        [MenuItem("MVP/Create/GameObject/MVP Manager")]
        [MenuItem("GameObject/MVP/MVP Manager")]
        static void CreateMVPManager(MenuCommand command)
        {
            if (Object.FindAnyObjectByType<MVPManager>() != null)
            {
                EditorUtility.DisplayDialog(
                    "Already Exists",
                    "MVPManager already exists in the scene.",
                    "OK");
                return;
            }

            var go = new GameObject("MVP Manager");
            go.AddComponent<MVPManager>();

            GameObjectUtility.SetParentAndAlign(go, command.context as GameObject);
            Undo.RegisterCreatedObjectUndo(go, "Create MVP Manager");
            Selection.activeObject = go;
        }
    }
}
#endif
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using KNTy.MVP.Runtime;
using UnityEditor.ShortcutManagement;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScript
    {
        string[] _modelNames;
        int _modelIndex;
        string[] _presenterNames;
        string _presenterName;
        int _presenterIndex;

        static void OpenCreatePresenterCoreMenu()
        {
            OpenCreatePresenterCore();
        }

        static void OpenCreatePresenterCore()
        {

        }

        static void CreatePresenterCore()
        {

        }

        [MenuItem("MVP/Create/Script/PartialPresenter")]
        [MenuItem("Assets/Create/MVP/PartialPresenter")]
        static void OpenCreatePartialPresenterMenu()
        {
            OpenCreatePartialPresenter();
        }

        [Shortcut("MVP/Create PartialPresenter", KeyCode.P, ShortcutModifiers.Control)]
        static void OpenCreatePartialPresenter()
        {
            var window = GetWindow<CreateMVPScript>("Create PartialPresenter");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._presenterName = "New";
            window.CollectModels();
            window.CollectPresenters();
            window._createMenu = CreateMenu.PartialPresenter;
        }

        void PartialPresenterWindow()
        {
            GUILayout.Label("PartialPresenter", EditorStyles.boldLabel);
            _modelIndex = EditorGUILayout.Popup("Target Model", _modelIndex, _modelNames);
            if (_presenterNames.Length > 0)
            {
                _presenterIndex = EditorGUILayout.Popup("Presenter Type", _presenterIndex, _presenterNames);
                var pressed = GUILayout.Button("Create");
                var e = Event.current;
                if (e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    pressed = true;
                    e.Use();
                }
                if (pressed)
                {
                    CreatePartialPresenter(_presenterNames[_presenterIndex], _modelNames[_modelIndex]);
                    Close();
                }
            }
            else
            {
                _presenterName = EditorGUILayout.TextField("Presenter Name", _presenterName);
                using (new EditorGUI.DisabledGroupScope(string.IsNullOrEmpty(_presenterName)))
                {
                    var pressed = GUILayout.Button("Create");
                    var e = Event.current;
                    if (e.type == EventType.KeyDown &&
                        (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                    {
                        pressed = true;
                        e.Use();
                    }
                    if (pressed)
                    {
                        CreatePartialPresenter(_presenterName, _modelNames[_modelIndex]);
                        Close();
                    }
                }
            }
        }

        void CreatePartialPresenter(string presenterName, string modelName)
        {
            var root = EnsureMPVRootFolder();
            var presenterPath = EnsureFolder(root, "Presenter");
            presenterName = presenterName.Replace("Presenter", "");
            modelName = modelName.Replace("RuntimeModel", "");

            CreateScript(presenterPath, $"{presenterName}Presenter_{modelName}.cs", PartialPresenter(presenterName, modelName));

            AssetDatabase.Refresh();
        }

        void CollectModels()
        {
            var list = new List<string>();
            var guids = AssetDatabase.FindAssets("t:MonoScript", new string[] { "Assets/Scripts/MVP/RuntimeModel" });

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
                var type = mono?.GetClass();
                if (type == null) continue;

                if (typeof(IRuntimeModel).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                {
                    list.Add(type.Name);
                }
            }

            _modelNames = list.ToArray();
        }

        void CollectPresenters()
        {
            var list = new List<string>();
            var guids = AssetDatabase.FindAssets("t:MonoScript", new string[] { "Assets/Scripts/MVP/Presenter" });

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var mono = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
                var type = mono?.GetClass();
                if (type == null) continue;

                if (typeof(IPresenter).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                {
                    list.Add(type.Name);
                }
            }

            _presenterNames = list.ToArray();
        }
    }
}

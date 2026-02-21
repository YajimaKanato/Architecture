using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEditorInternal;
using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScriptWindow
    {
        ReorderableList _reorderableList;
        List<string> _selectedModels = new();
        string[] _modelNames;
        int _modelIndex;
        string[] _presenterNames;
        int _presenterIndex;

        [MenuItem("MVP/Create/Script/PresenterCore", true)]
        [MenuItem("Assets/Create/MVP/PresenterCore", true)]
        static bool ValidateCreatingPresenterCore()
        {
            return ScriptCollection.PresenterNames.Count > 0;
        }

        [MenuItem("MVP/Create/Script/PresenterCore")]
        [MenuItem("Assets/Create/MVP/PresenterCore")]
        static void OpenCreatePresenterCoreFromMenu()
        {
            OpenCreatePresenterCore();
        }

        [Shortcut("MVP/Create PresenterCore", KeyCode.C, ShortcutModifiers.Control)]
        static void OpenCreatePresenterCore()
        {
            var window = GetWindow<CreateMVPScriptWindow>("Create PresenterCore");
            Vector2 windowSize = new Vector2(350, 100);
            window.minSize = windowSize;
            window._modelNames = ScriptCollection.ModelNames.ToArray();
            window._selectedModels.Add(window._modelNames[0]);
            window._presenterNames = ScriptCollection.PresenterNames.ToArray();
            window._presenterIndex = 0;
            window._createMenu = CreateMenu.PresenterCore;
        }

        void PresenterCoreWindowSetup()
        {
            _reorderableList = new(_selectedModels, typeof(string), true, false, true, true);
            _reorderableList.onAddCallback = _ => _selectedModels.Add(_modelNames[0]);
            _reorderableList.onRemoveCallback = _ => _selectedModels.RemoveAt(0);
        }

        void PresenterCoreWindow()
        {
            GUILayout.Label("PresenterCore", EditorStyles.boldLabel);
            _reorderableList.DoLayoutList();

            _isFinished = GUILayout.Button("Create");
            var e = Event.current;
            if (e.type == EventType.KeyDown &&
                (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
            {
                _isFinished = true;
                e.Use();
            }
            //if (_isFinished) CreateMVPScript.CreatePresenterCore(_presenterName);
        }

        [MenuItem("MVP/Create/Script/PartialPresenter", true)]
        [MenuItem("Assets/Create/MVP/PartialPresenter", true)]
        static bool ValidateCreatingPartialPresenter()
        {
            return ScriptCollection.PresenterNames.Count > 0 && ScriptCollection.ModelNames.Count > 0;
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
            var window = GetWindow<CreateMVPScriptWindow>("Create PartialPresenter");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._modelNames = ScriptCollection.ModelNames.ToArray();
            window._modelIndex = 0;
            window._presenterNames = ScriptCollection.PresenterNames.ToArray();
            window._presenterIndex = 0;
            window._createMenu = CreateMenu.PartialPresenter;
        }

        void PartialPresenterWindow()
        {
            GUILayout.Label("PartialPresenter", EditorStyles.boldLabel);
            _modelIndex = EditorGUILayout.Popup("Target Model", _modelIndex, _modelNames);
            _presenterIndex = EditorGUILayout.Popup("Presenter Type", _presenterIndex, _presenterNames);

            _isFinished = GUILayout.Button("Create");
            var e = Event.current;
            if (e.type == EventType.KeyDown &&
                (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
            {
                _isFinished = true;
                e.Use();
            }
            if (_isFinished) CreateMVPScript.CreatePartialPresenter(_presenterNames[_presenterIndex], _modelNames[_modelIndex]);
        }
    }
}

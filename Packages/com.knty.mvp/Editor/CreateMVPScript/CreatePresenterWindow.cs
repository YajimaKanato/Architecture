#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace KNTy.MVP.Editor
{
    internal partial class CreateMVPScriptWindow
    {
        ReorderableList _reorderableList;
        List<string> _selectedModels = new();
        Vector2 _scroll;
        int _maxVisible = 5;
        string[] _runtimeModelNames;
        int _runtimeModelIndex;
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
            if (EditorApplication.isCompiling || EditorApplication.isUpdating)
                SessionState.SetBool("OpenCreatePresenterCoreFromMenu", true);
        }

        [InitializeOnLoadMethod]
        static void ResumeCreatingPresenterCore()
        {
            if (!SessionState.GetBool("OpenCreatePresenterCoreFromMenu", false)) return;
            SessionState.EraseBool("OpenCreatePresenterCoreFromMenu");
            OpenCreatePresenterCore();
        }

        static void OpenCreatePresenterCore()
        {
            var window = GetWindow<CreateMVPScriptWindow>("Create PresenterCore");
            Vector2 windowSize = new Vector2(350, 230);
            window.maxSize = window.minSize = windowSize;
            window._runtimeModelNames = ScriptCollection.RuntimeModelNames.ToArray();
            window._selectedModels.Add(window._runtimeModelNames[0]);
            window._presenterNames = ScriptCollection.PresenterNames.ToArray();
            window._presenterIndex = 0;
            window._createMenu = CreateMenu.PresenterCore;
        }

        void PresenterCoreWindowSetup()
        {
            _reorderableList = new(_selectedModels, typeof(string), true, true, true, true);
            _reorderableList.drawHeaderCallback = rect => EditorGUI.LabelField(rect, "RuntimeModels");
            _reorderableList.drawElementCallback = (rect, index, active, focused) =>
            {
                rect.y += 2;

                var available = _runtimeModelNames.Where(c => !_selectedModels.Contains(c) || c == _selectedModels[index]).ToArray();

                int current = Array.IndexOf(available, _selectedModels[index]);
                if (current < 0) current = 0;

                int next = EditorGUI.Popup(rect, current, available);
                _selectedModels[index] = available[next];
            };
            _reorderableList.onAddCallback = list =>
            {
                foreach (var item in _runtimeModelNames)
                {
                    if (!_selectedModels.Contains(item))
                    {
                        _selectedModels.Add(item);
                        return;
                    }
                }
            };
            _reorderableList.onRemoveCallback = list =>
            {
                int index = list.index > 0 ? list.index : _selectedModels.Count - 1;
                if (index >= 0) _selectedModels.RemoveAt(index);
            };
            _reorderableList.onCanAddCallback = _ => _selectedModels.Count < _runtimeModelNames.Length;
        }

        void PresenterCoreWindow()
        {
            GUILayout.Label("PresenterCore", EditorStyles.boldLabel);
            _presenterIndex = EditorGUILayout.Popup("Presenter Type", _presenterIndex, _presenterNames);

            float fullHeight = _reorderableList.GetHeight();
            float visibleHeight = fullHeight;
            if (_selectedModels.Count > _maxVisible)
            {
                float headerFooter = 40f;
                float elementHeight = (fullHeight - headerFooter) / _selectedModels.Count;
                visibleHeight = headerFooter / 2 + elementHeight * _maxVisible;
            }

            _scroll = EditorGUILayout.BeginScrollView(_scroll, GUILayout.Height(visibleHeight));
            _reorderableList.DoLayoutList();
            EditorGUILayout.EndScrollView();

            GUILayout.FlexibleSpace();

            using (new EditorGUI.DisabledScope(_selectedModels.Count <= 0))
            {
                _isFinished = GUILayout.Button("Create");
                GUILayout.Space(10);
                var e = Event.current;
                if (e.type == EventType.KeyDown &&
                    (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
                {
                    _isFinished = true;
                    e.Use();
                }
                if (_isFinished)
                {
                    var runtimeModels = _selectedModels.Select(s => s.Replace("RuntimeModel", ""));
                    var argumentList = runtimeModels.Select(s => $"{s}RuntimeModel {s.ToLower()}RuntimeModel");
                    var argument = string.Join(",\n\t\t", argumentList);
                    var variableList = runtimeModels.Select(s => $"\t{s}RuntimeModel _{s.ToLower()}RuntimeModel;");
                    var variable = string.Join("\n", variableList);
                    var assignmentList = runtimeModels.Select(s => $"\t\t_{s.ToLower()}RuntimeModel = {s.ToLower()}RuntimeModel;");
                    var assignment = string.Join("\n", assignmentList);
                    var presenterName = _presenterNames[_presenterIndex].Replace("Presenter", "");
                    CreateMVPScript.CreatePresenterCore(presenterName, argument, variable, assignment);
                }
            }
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
            if (EditorApplication.isCompiling || EditorApplication.isUpdating)
                SessionState.SetBool("OpenCreatePartialPresenterMenu", true);
        }

        [InitializeOnLoadMethod]
        static void ResumeCreatingPartialPresenter()
        {
            if (!SessionState.GetBool("OpenCreatePartialPresenterMenu", false)) return;
            SessionState.EraseBool("OpenCreatePartialPresenterMenu");
            OpenCreatePartialPresenter();
        }

        static void OpenCreatePartialPresenter()
        {
            var window = GetWindow<CreateMVPScriptWindow>("Create PartialPresenter");
            Vector2 windowSize = new Vector2(350, 100);
            window.maxSize = window.minSize = windowSize;
            window._runtimeModelNames = ScriptCollection.RuntimeModelNames.ToArray();
            window._runtimeModelIndex = 0;
            window._presenterNames = ScriptCollection.PresenterNames.ToArray();
            window._presenterIndex = 0;
            window._createMenu = CreateMenu.PartialPresenter;
        }

        void PartialPresenterWindow()
        {
            GUILayout.Label("PartialPresenter", EditorStyles.boldLabel);
            _presenterIndex = EditorGUILayout.Popup("Presenter Type", _presenterIndex, _presenterNames);
            _runtimeModelIndex = EditorGUILayout.Popup("Target Model", _runtimeModelIndex, _runtimeModelNames);

            _isFinished = GUILayout.Button("Create");
            var e = Event.current;
            if (e.type == EventType.KeyDown &&
                (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
            {
                _isFinished = true;
                e.Use();
            }
            if (_isFinished) CreateMVPScript.CreatePartialPresenter(_presenterNames[_presenterIndex], _runtimeModelNames[_runtimeModelIndex]);
        }
    }
}
#endif
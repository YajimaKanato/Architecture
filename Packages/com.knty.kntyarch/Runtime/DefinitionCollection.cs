using UnityEngine;

namespace KNTyArch.Runtime
{
    /// <summary>ゲーム全体で扱うDefinitionをすべて格納したクラス</summary>
    public sealed class DefinitionCollection : ScriptableObject
    {
        [SerializeField, Tooltip("ゲーム全体で扱うすべてのDefinition")] DefinitionBase[] _definitionList;

        public DefinitionBase[] definitionList => _definitionList;

#if UNITY_EDITOR
        public void SetModels(DefinitionBase[] definitionList)
        {
            _definitionList = definitionList;
        }
#endif
    }
}

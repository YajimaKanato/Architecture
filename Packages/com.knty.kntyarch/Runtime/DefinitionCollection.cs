using UnityEngine;

namespace KNTyArch.Runtime
{
    public sealed class DefinitionCollection : ScriptableObject
    {
        [SerializeField] DefinitionBase[] _definitionList;

        public DefinitionBase[] definitionList => _definitionList;

#if UNITY_EDITOR
        public void SetModels(DefinitionBase[] definitionList)
        {
            _definitionList = definitionList;
        }
#endif
    }
}

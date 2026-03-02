using UnityEngine;

namespace KNTyArch.Runtime
{
    public sealed class ModelCollection : ScriptableObject
    {
        [SerializeField] ModelBase[] _modelList;

        public ModelBase[] ModelList => _modelList;

#if UNITY_EDITOR
        public void SetModels(ModelBase[] modelList)
        {
            _modelList = modelList;
        }
#endif
    }
}

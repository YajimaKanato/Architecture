using System;
using System.Collections.Generic;
using UnityEngine;

namespace KNTy.MVP.Runtime
{
    [CreateAssetMenu(fileName = "ModelIDList", menuName = "ModelIDList")]
    public sealed class ModelIDList : ScriptableObject
    {
        [SerializeField] ModelID[] _IDList;

        public ModelID[] IDList => _IDList;
    }

    [Serializable]
    public sealed class ModelID
    {
        [SerializeField] ModelBase _modelType;
        [SerializeField] List<ID> _ids;
    }
}

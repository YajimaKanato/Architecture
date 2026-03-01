using System;
using UnityEngine;

namespace KNTy.MVP.Runtime
{
    [Serializable]
    public class ID
    {
        [SerializeField] string _stringID;

        public string StringID => _stringID;
    }
}

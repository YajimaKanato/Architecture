using System;
using UnityEngine;

namespace KNTyArch.Runtime
{
    [Serializable]
    public class ID
    {
        [SerializeField] string _stringID;

        public string StringID => _stringID;

        public bool Equals(ID other) => throw new NotImplementedException();

        public override bool Equals(object obj) => Equals(obj as ID);

        public override int GetHashCode() => throw new NotImplementedException();
    }
}

using UnityEngine;
using System;

namespace KNTyArch.Runtime
{
    public abstract class ViewBase : MonoBehaviour
    {
        [SerializeField] protected string _id;
        public string ID => _id;
        public abstract Type ModelType();
        public abstract void Initialize();
    }

    public abstract class ViewBase<TRuntimeModel> : ViewBase where TRuntimeModel : RuntimeBase
    {
        public override Type ModelType() => typeof(TRuntimeModel);
    }
}

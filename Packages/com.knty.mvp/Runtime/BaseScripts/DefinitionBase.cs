using UnityEngine;
using System;

namespace KNTyArch.Runtime
{
    public abstract class DefinitionBase : ScriptableObject
    {
        public abstract Type GetRuntimeType();
        public abstract Type GetViewDataType();
        public abstract RuntimeBase CreateRuntime();
        public abstract ViewDataBase CreateViewData();
    }

    public abstract class DefinitionBase<TRuntime, TViewData> : DefinitionBase where TRuntime : RuntimeBase where TViewData : ViewDataBase
    {
        public sealed override Type GetRuntimeType() => typeof(TRuntime);

        public sealed override Type GetViewDataType() => typeof(TViewData);

        public sealed override RuntimeBase CreateRuntime()
        {
            return CreateTypedRuntime();
        }

        public sealed override ViewDataBase CreateViewData()
        {
            return CreateTypedViewData();
        }

        public abstract TRuntime CreateTypedRuntime();
        public abstract TViewData CreateTypedViewData();
    }
}

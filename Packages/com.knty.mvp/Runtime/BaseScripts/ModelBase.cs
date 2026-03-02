using UnityEngine;
using System;

namespace KNTy.MVP.Runtime
{
    public abstract class ModelBase : ScriptableObject
    {
        public abstract Type GetRuntimeModelType();
        public abstract Type GetViewModelType();
        public abstract RuntimeModelBase CreateRuntimeModel();
        public abstract ViewModelBase CreateViewModel();
    }

    public abstract class ModelBase<TRuntimeModel, TViewModel> : ModelBase where TRuntimeModel : RuntimeModelBase where TViewModel : ViewModelBase
    {
        public sealed override Type GetRuntimeModelType() => typeof(TRuntimeModel);

        public sealed override Type GetViewModelType() => typeof(TViewModel);

        public sealed override RuntimeModelBase CreateRuntimeModel()
        {
            return CreateTypedRuntimeModel();
        }

        public sealed override ViewModelBase CreateViewModel()
        {
            return CreateTypedViewModel();
        }

        public abstract TRuntimeModel CreateTypedRuntimeModel();
        public abstract TViewModel CreateTypedViewModel();
    }
}

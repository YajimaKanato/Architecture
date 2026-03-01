using UnityEngine;

namespace KNTy.MVP.Runtime
{
    public abstract class ModelBase : ScriptableObject
    {
        public abstract RuntimeModelBase CreateRuntimeModel();
        public abstract IViewModel CreateViewModel();
    }

    public abstract class ModelBase<TRuntimeModel, TViewModel> : ModelBase where TRuntimeModel : RuntimeModelBase where TViewModel : struct, IViewModel
    {
        public sealed override RuntimeModelBase CreateRuntimeModel()
        {
            return CreateTypedRuntimeModel();
        }

        public sealed override IViewModel CreateViewModel()
        {
            return CreateTypedViewModel();
        }

        public abstract TRuntimeModel CreateTypedRuntimeModel();
        public abstract TViewModel CreateTypedViewModel();
    }
}

using UnityEngine;

namespace KNTyArch.Runtime
{
    internal sealed class PresenterFactoryStateMachine
    {
        IPresenterFactory _factory;

        internal void ChangeFactory(IPresenterFactory factory)
        {
            _factory?.Dispose();
            _factory = factory;
            _factory?.GeneratePresenter();
        }
    }
}

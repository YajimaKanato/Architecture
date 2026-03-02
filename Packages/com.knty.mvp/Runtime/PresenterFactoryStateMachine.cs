using UnityEngine;

namespace KNTyArch.Runtime
{
    internal sealed class PresenterFactoryStateMachine
    {
        RuntimeModelStorage _runtimeModelStorage;
        ViewModelStorage _viewModelStorage;
        IEventHub _inputHub;
        IEventHub _eventHub;
        IPresenterFactory _factory;

        public PresenterFactoryStateMachine(RuntimeModelStorage storage_RM, ViewModelStorage storage_VM, IEventHub inputHub, IEventHub eventHub)
        {
            _runtimeModelStorage = storage_RM;
            _viewModelStorage = storage_VM;
            _inputHub = inputHub;
            _eventHub = eventHub;
        }

        internal void ChangeFactory(IPresenterFactory factory)
        {
            _factory?.Dispose();
            _factory = factory;
            _factory?.GeneratePresenter(_runtimeModelStorage, _viewModelStorage, _inputHub, _eventHub);

        }
    }
}

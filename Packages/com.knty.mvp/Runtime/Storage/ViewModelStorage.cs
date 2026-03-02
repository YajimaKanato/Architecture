using System;
using System.Collections.Generic;

namespace KNTyArch.Runtime
{
    public sealed class ViewModelStorage : IDisposable
    {
        readonly Dictionary<Type, VaultBase<ViewModelBase>> _storage = new();
        readonly Dictionary<Type, Func<ViewModelBase>> _modelGenerateDict = new();

        public ViewModelStorage(ModelCollection modelCollection)
        {
            var list = modelCollection.ModelList;
            foreach (var model in list)
            {
                _modelGenerateDict[model.GetViewModelType()] = model.CreateViewModel;
            }
        }

        void GetOrCreateVault(Type type, out VaultBase<ViewModelBase> vault)
        {
            if (!_storage.TryGetValue(type, out vault))
            {
                vault = new VaultBase<ViewModelBase>();
                _storage[type] = vault;
            }
        }

        bool GetVault(Type type, out VaultBase<ViewModelBase> vault)
        {
            _storage.TryGetValue(type, out vault);
            return vault != null;
        }

        public bool TryRegister(Type type, ID id)
        {
            if (!_modelGenerateDict.TryGetValue(type, out var func)) return false;
            var viewModel = func();
            GetOrCreateVault(type, out var vault);
            return vault.TryRegister(id, viewModel);
        }

        public bool TryGetModel(Type type, ID id, out ViewModelBase viewModel)
        {
            if (GetVault(type, out var vault) && vault.TryGetModel(id, out viewModel))
                return true;

            viewModel = default;
            return false;
        }

        public bool TryUnregister(Type type, ID id)
        {
            return GetVault(type, out var vault) && vault.TryUnregister(id);
        }

        public void Dispose()
        {
            foreach (var v in _storage.Values)
            {
                v.Dispose();
            }
            _storage.Clear();
            _modelGenerateDict.Clear();
        }
    }
}

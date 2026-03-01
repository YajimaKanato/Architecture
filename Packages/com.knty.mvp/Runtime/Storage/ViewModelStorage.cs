using System;
using System.Collections.Generic;

namespace KNTy.MVP.Runtime
{
    public sealed class ViewModelStorage : IDisposable
    {
        readonly Dictionary<Type, IVault> _storage = new();

        public ViewModelStorage()
        {

        }

        bool GetOrCreateVault<TViewModel>(out ViewModelVault<TViewModel> vault) where TViewModel : struct, IViewModel
        {
            var type = typeof(TViewModel);
            if (!_storage.TryGetValue(type, out var v))
            {
                v = new ViewModelVault<TViewModel>();
                _storage[type] = v;
            }

            vault = (ViewModelVault<TViewModel>)v;
            return vault != null;
        }

        bool GetVault<TViewModel>(out ViewModelVault<TViewModel> vault) where TViewModel : struct, IViewModel
        {
            _storage.TryGetValue(typeof(TViewModel), out var v);
            vault = (ViewModelVault<TViewModel>)v;
            return vault != null;
        }

        public bool TryRegister<TViewModel>(int id, TViewModel runtimeModel) where TViewModel : struct, IViewModel
        {
            if (!GetOrCreateVault<TViewModel>(out var vault)) return false;
            return vault.TryRegister(id, runtimeModel);
        }

        public bool TryGetModel<TViewModel>(int id, out TViewModel runtimeModel) where TViewModel : struct, IViewModel
        {
            if (GetVault<TViewModel>(out var vault) && vault.TryGetModel(id, out runtimeModel))
                return true;

            runtimeModel = default;
            return false;
        }

        public bool TryUnregister<TViewModel>(int id) where TViewModel : struct, IViewModel
        {
            return GetVault<TViewModel>(out var vault) && vault.TryUnregister(id);
        }

        public void Dispose()
        {
            foreach (var v in _storage.Values)
            {
                (v as IDisposable)?.Dispose();
            }
            _storage.Clear();
        }
    }
}

using System;
using System.Collections.Generic;

namespace KNTy.MVP.Runtime
{
    public sealed class RuntimeModelStorage : IDisposable
    {
        readonly Dictionary<Type, IVault> _storage = new();

        public RuntimeModelStorage()
        {

        }

        bool GetOrCreateVault<TRuntimeModel>(out RuntimeModelVault<TRuntimeModel> vault) where TRuntimeModel : RuntimeModelBase
        {
            var type = typeof(TRuntimeModel);
            if (!_storage.TryGetValue(type, out var v))
            {
                v = new RuntimeModelVault<TRuntimeModel>();
                _storage[type] = v;
            }

            vault = (RuntimeModelVault<TRuntimeModel>)v;
            return vault != null;
        }

        bool GetVault<TRuntimeModel>(out RuntimeModelVault<TRuntimeModel> vault) where TRuntimeModel : RuntimeModelBase
        {
            _storage.TryGetValue(typeof(TRuntimeModel), out var v);
            vault = (RuntimeModelVault<TRuntimeModel>)v;
            return vault != null;
        }

        public bool TryRegister<TRuntimeModel>(int id, TRuntimeModel runtimeModel) where TRuntimeModel : RuntimeModelBase
        {
            if (!GetOrCreateVault<TRuntimeModel>(out var vault)) return false;
            return vault.TryRegister(id, runtimeModel);
        }

        public bool TryGetModel<TRuntimeModel>(int id, out TRuntimeModel runtimeModel) where TRuntimeModel : RuntimeModelBase
        {
            if (GetVault<TRuntimeModel>(out var vault) && vault.TryGetModel(id, out runtimeModel))
                return true;

            runtimeModel = default;
            return false;
        }

        public bool TryUnregister<TRuntimeModel>(int id) where TRuntimeModel : RuntimeModelBase
        {
            return GetVault<TRuntimeModel>(out var vault) && vault.TryUnregister(id);
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

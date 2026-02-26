using System;
using System.Collections.Generic;

namespace KNTy.MVP.Runtime
{
    public sealed class RuntimeModelStorage : IDisposable
    {
        readonly Dictionary<Type, IRuntimeModelVault> _storage = new();

        bool GetOrCreateRuntimeModelVault<TRuntimeModel>(out RuntimeModelVault<TRuntimeModel> vault) where TRuntimeModel : RuntimeModelBase
        {
            var type = typeof(TRuntimeModel);
            if (!(_storage.TryGetValue(type, out var v) && v is RuntimeModelVault<TRuntimeModel>))
                _storage[type] = new RuntimeModelVault<TRuntimeModel>();

            vault = _storage[type] as RuntimeModelVault<TRuntimeModel>;
            return vault != null;
        }

        bool GetRuntimeModelVault<TRuntimeModel>(out RuntimeModelVault<TRuntimeModel> vault) where TRuntimeModel : RuntimeModelBase
        {
            _storage.TryGetValue(typeof(TRuntimeModel), out var v);
            vault = v as RuntimeModelVault<TRuntimeModel>;
            return vault != null;
        }

        public bool TryRegister<TRuntimeModel>(int id, TRuntimeModel runtimeModel) where TRuntimeModel : RuntimeModelBase
        {
            if (!GetOrCreateRuntimeModelVault<TRuntimeModel>(out var vault)) return false;
            return vault.TryRegister(id, runtimeModel);
        }

        public bool TryGetRuntimeModel<TRuntimeModel>(int id, out TRuntimeModel runtimeModel) where TRuntimeModel : RuntimeModelBase
        {
            if (!(GetRuntimeModelVault<TRuntimeModel>(out var vault) && vault.TryGetRuntimeModel(id, out var rm)))
            {
                runtimeModel = default;
                return false;
            }
            else
            {
                runtimeModel = rm;
                return true;
            }
        }

        public bool TryUnregister<TRuntimeModel>(int id) where TRuntimeModel : RuntimeModelBase
        {
            return GetRuntimeModelVault<TRuntimeModel>(out var vault) && vault.TryUnregister(id);
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

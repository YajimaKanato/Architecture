using System;
using System.Collections.Generic;

namespace KNTy.MVP.Runtime
{
    public abstract class StorageBase<TModel> : IDisposable
    {
        readonly Dictionary<Type, IVault> _storage = new();

        protected abstract IVault CreateVault<T>() where T : TModel;

        bool GetOrCreateVault<T>(out VaultBase<T> vault) where T : TModel
        {
            var type = typeof(T);
            if (!_storage.TryGetValue(type, out var v))
            {
                v = CreateVault<T>();
                _storage[type] = v;
            }

            vault = (VaultBase<T>)v;
            return vault != null;
        }

        bool GetVault<T>(out VaultBase<T> vault) where T : TModel
        {
            _storage.TryGetValue(typeof(T), out var v);
            vault = (VaultBase<T>)v;
            return vault != null;
        }

        public bool TryRegister<T>(int id, T runtimeModel) where T : TModel
        {
            if (!GetOrCreateVault<T>(out var vault)) return false;
            return vault.TryRegister(id, runtimeModel);
        }

        public bool TryGetRuntimeModel<T>(int id, out T runtimeModel) where T : TModel
        {
            if (GetVault<T>(out var vault) && vault.TryGetRuntimeModel(id, out runtimeModel))
                return true;

            runtimeModel = default;
            return false;
        }

        public bool TryUnregister<T>(int id) where T : TModel
        {
            return GetVault<T>(out var vault) && vault.TryUnregister(id);
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

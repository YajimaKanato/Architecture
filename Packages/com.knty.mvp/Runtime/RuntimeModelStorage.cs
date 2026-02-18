using System;
using System.Collections.Generic;

namespace KNTy.MVP.Runtime
{
    public sealed class RuntimeModelStorage : IDisposable
    {
        readonly Dictionary<Type, IRuntimeModelVault> _storage = new();

        bool GetOrCreateRuntimeModelVault<TRuntimeModel>(out RuntimeModelVault<TRuntimeModel> vault) where TRuntimeModel : IRuntimeModel
        {
            var type = typeof(TRuntimeModel);
            if (!(_storage.TryGetValue(type, out var v) && v is RuntimeModelVault<TRuntimeModel>))
                _storage[type] = new RuntimeModelVault<TRuntimeModel>();

            vault = _storage[type] as RuntimeModelVault<TRuntimeModel>;
            return vault != null;
        }

        bool GetRuntimeModelVault<TRuntimeModel>(out RuntimeModelVault<TRuntimeModel> vault) where TRuntimeModel : IRuntimeModel
        {
            _storage.TryGetValue(typeof(TRuntimeModel), out var v);
            vault = v as RuntimeModelVault<TRuntimeModel>;
            return vault != null;
        }

        public bool TryRegister<TRuntimeModel>(int id, TRuntimeModel runtimeModel) where TRuntimeModel : IRuntimeModel
        {
            if (!GetOrCreateRuntimeModelVault<TRuntimeModel>(out var vault)) return false;
            return vault.TryRegister(id, runtimeModel);
        }

        public bool TryGetRuntimeModel<TRuntimeModel>(int id, out TRuntimeModel runtimeModel) where TRuntimeModel : IRuntimeModel
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

        public bool TryUnregister<TRuntimeModel>(int id) where TRuntimeModel : IRuntimeModel
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

    internal sealed class RuntimeModelVault<TRuntimeModel> : IRuntimeModelVault where TRuntimeModel : IRuntimeModel
    {
        readonly Dictionary<int, TRuntimeModel> _vault = new();

        public bool TryRegister(int id, TRuntimeModel runtimeModel)
        {
            return _vault.TryAdd(id, runtimeModel);
        }

        public bool TryGetRuntimeModel(int id, out TRuntimeModel runtimeModel)
        {
            return _vault.TryGetValue(id, out runtimeModel);
        }

        public bool TryUnregister(int id)
        {
            if (!_vault.TryGetValue(id, out TRuntimeModel runtimeModel)) return false;
            (runtimeModel as IDisposable)?.Dispose();
            _vault.Remove(id);
            return true;
        }

        public void Dispose()
        {
            foreach (var runtimeModel in _vault.Values)
            {
                (runtimeModel as IDisposable)?.Dispose();
            }
            _vault.Clear();
        }
    }

    internal interface IRuntimeModelVault : IDisposable { }
}

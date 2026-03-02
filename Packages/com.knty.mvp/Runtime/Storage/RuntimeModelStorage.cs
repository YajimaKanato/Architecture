using System;
using System.Collections.Generic;

namespace KNTy.MVP.Runtime
{
    public sealed class RuntimeModelStorage : IDisposable
    {
        readonly Dictionary<Type, VaultBase<RuntimeModelBase>> _storage = new();
        readonly Dictionary<Type, Func<RuntimeModelBase>> _modelGenerateDict = new();

        public RuntimeModelStorage(ModelCollection modelCollection)
        {
            var list = modelCollection.ModelList;
            foreach (var model in list)
            {
                _modelGenerateDict[model.GetRuntimeModelType()] = model.CreateRuntimeModel;
            }
        }

        void GetOrCreateVault(Type type, out VaultBase<RuntimeModelBase> vault)
        {
            if (!_storage.TryGetValue(type, out vault))
            {
                vault = new VaultBase<RuntimeModelBase>();
                _storage[type] = vault;
            }
        }

        bool GetVault(Type type, out VaultBase<RuntimeModelBase> vault)
        {
            _storage.TryGetValue(type, out vault);
            return vault != null;
        }

        public bool TryRegister(Type type, ID id)
        {
            if (!_modelGenerateDict.TryGetValue(type, out var func)) return false;
            var runtimeModel = func();
            GetOrCreateVault(type, out var vault);
            return vault.TryRegister(id, runtimeModel);
        }

        public bool TryGetModel(Type type, ID id, out RuntimeModelBase runtimeModel)
        {
            if (GetVault(type, out var vault) && vault.TryGetModel(id, out runtimeModel))
                return true;

            runtimeModel = default;
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

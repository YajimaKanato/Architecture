using System;
using System.Collections.Generic;

namespace KNTyArch.Runtime
{
    public static class RuntimeStorage
    {
        static readonly Dictionary<Type, VaultBase<RuntimeBase>> _storage = new();
        static readonly Dictionary<Type, Func<RuntimeBase>> _modelGenerateDict = new();

        public static void SetRuntimeGenerating(DefinitionCollection definitionCollection)
        {
            var list = definitionCollection.definitionList;
            foreach (var model in list)
            {
                _modelGenerateDict[model.GetRuntimeType()] = model.CreateRuntime;
            }
        }

        static void GetOrCreateVault(Type type, out VaultBase<RuntimeBase> vault)
        {
            if (!_storage.TryGetValue(type, out vault))
            {
                vault = new VaultBase<RuntimeBase>();
                _storage[type] = vault;
            }
        }

        static bool GetVault(Type type, out VaultBase<RuntimeBase> vault)
        {
            _storage.TryGetValue(type, out vault);
            return vault != null;
        }

        public static bool TryRegister(Type type, string id)
        {
            if (!_modelGenerateDict.TryGetValue(type, out var func)) return false;
            var runtime = func();
            GetOrCreateVault(type, out var vault);
            return vault.TryRegister(id, runtime);
        }

        public static bool TryGetModel(Type type, string id, out RuntimeBase runtime)
        {
            if (GetVault(type, out var vault) && vault.TryGetModel(id, out runtime))
                return true;

            runtime = default;
            return false;
        }

        public static bool TryUnregister(Type type, string id)
        {
            return GetVault(type, out var vault) && vault.TryUnregister(id);
        }

        public static void Clear()
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

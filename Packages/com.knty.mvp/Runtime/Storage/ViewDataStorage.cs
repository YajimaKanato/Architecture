using System;
using System.Collections.Generic;

namespace KNTyArch.Runtime
{
    public static class ViewDataStorage
    {
        static readonly Dictionary<Type, VaultBase<ViewDataBase>> _storage = new();
        static readonly Dictionary<Type, Func<ViewDataBase>> _modelGenerateDict = new();

        public static void SetViewDataGenerating(DefinitionCollection definitionCollection)
        {
            var list = definitionCollection.definitionList;
            foreach (var model in list)
            {
                _modelGenerateDict[model.GetViewDataType()] = model.CreateViewData;
            }
        }

        static void GetOrCreateVault(Type type, out VaultBase<ViewDataBase> vault)
        {
            if (!_storage.TryGetValue(type, out vault))
            {
                vault = new VaultBase<ViewDataBase>();
                _storage[type] = vault;
            }
        }

        static bool GetVault(Type type, out VaultBase<ViewDataBase> vault)
        {
            _storage.TryGetValue(type, out vault);
            return vault != null;
        }

        public static bool TryRegister(Type type, string id)
        {
            if (!_modelGenerateDict.TryGetValue(type, out var func)) return false;
            var viewData = func();
            GetOrCreateVault(type, out var vault);
            return vault.TryRegister(id, viewData);
        }

        public static bool TryGetModel(Type type, string id, out ViewDataBase viewData)
        {
            if (GetVault(type, out var vault) && vault.TryGetModel(id, out viewData))
                return true;

            viewData = default;
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

using System;
using System.Collections.Generic;

namespace KNTyArch.Runtime
{
    public static class ViewDataStorage
    {
        /// <summary>Definitionのデータ型とその保管場所の対応表</summary>
        static readonly Dictionary<Type, VaultBase<ViewDataBase>> _storage = new();
        /// <summary>Definitionのデータ型とその生成方法の対応表</summary>
        static readonly Dictionary<Type, Func<ViewDataBase>> _viewDataGenerateDict = new();
        /// <summary>インターフェースとデータの対応表</summary>
        static readonly InterfaceIndex<ViewDataBase> _interfaceIndex = new();

        /// <summary>
        /// DefinitionのリストからViewDataの生成方法を受け取り対応表を作成するメソッド
        /// </summary>
        /// <param name="definitionCollection">Definitionのリスト</param>
        public static void SetViewDataGenerating(DefinitionCollection definitionCollection)
        {
            var list = definitionCollection.definitionList;
            foreach (var definition in list)
            {
                _viewDataGenerateDict[definition.GetType()] = definition.CreateViewData;
            }
        }

        /// <summary>
        /// 保管場所を取得または作成するメソッド
        /// </summary>
        /// <param name="type">保管場所に対応するデータ型</param>
        /// <param name="vault">保管場所</param>
        static void GetOrCreateVault<TDefinition>(ModelHandle<TDefinition> handle, out VaultBase<ViewDataBase> vault)
            where TDefinition : DefinitionBase
        {
            var type = typeof(TDefinition);
            if (!_storage.TryGetValue(type, out vault))
            {
                vault = new VaultBase<ViewDataBase>();
                _storage[type] = vault;
            }
        }

        /// <summary>
        /// 保管場所を取得するメソッド
        /// </summary>
        /// <param name="type">保管場所に対応するデータ型</param>
        /// <param name="vault">保管場所</param>
        /// <returns>保管場所があるかどうか</returns>
        static bool TryGetVault<TDefinition>(ModelHandle<TDefinition> handle, out VaultBase<ViewDataBase> vault)
            where TDefinition : DefinitionBase
        {
            var type = typeof(TDefinition);
            if (_storage.TryGetValue(type, out var v) && v is VaultBase<ViewDataBase> typed)
            {
                vault = typed;
                return true;
            }
            vault = null;
            return false;
        }

        /// <summary>
        /// データ型に対応するRuntimeをIDに対して作成するメソッド
        /// </summary>
        /// <param name="type">データ型</param>
        /// <param name="id">ID</param>
        /// <returns>データ型を作成できたかどうか</returns>
        public static bool TryRegister<TDefinition>(ModelHandle<TDefinition> handle)
            where TDefinition : DefinitionBase
        {
            if (!_viewDataGenerateDict.TryGetValue(typeof(TDefinition), out var func)) return false;
            var viewData = func();
            GetOrCreateVault(handle, out VaultBase<ViewDataBase> vault);

            if (!vault.TryRegister(handle.ID, viewData)) return false;
            _interfaceIndex.Register(viewData);
            return true;
        }


        public static bool TryGetModel<TDefinition, TViewData>(ModelHandle<TDefinition> handle, out TViewData viewData)
            where TDefinition : DefinitionBase where TViewData : ViewDataBase
        {
            viewData = null;
            if (!TryGetVault(handle, out var vault)) return false;
            if (!vault.TryGetModel(handle.ID, out var r)) return false;
            if (r is not TViewData typed) return false;
            viewData = typed;
            return true;
        }

        public static List<TInterface> TryGetInterfaces<TInterface>() where TInterface : class
        {
            _interfaceIndex.TryGet(out List<TInterface> l);
            return l;
        }

        public static bool TryUnregister<TDefinition>(ModelHandle<TDefinition> handle)
            where TDefinition : DefinitionBase
        {
            if (!TryGetVault(handle, out VaultBase<ViewDataBase> vault)) return false;
            if (!vault.TryGetModel(handle.ID, out var viewData)) return false;
            _interfaceIndex.Unregister(viewData);
            vault.TryUnregister(handle.ID);
            return true;
        }

        public static void Clear()
        {
            foreach (var v in _storage.Values)
            {
                (v as IDisposable)?.Dispose();
            }
            _storage.Clear();
            _viewDataGenerateDict.Clear();
            _interfaceIndex.Clear();
        }
    }
}

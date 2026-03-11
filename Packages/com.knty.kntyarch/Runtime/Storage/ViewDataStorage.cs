using System;
using System.Collections.Generic;

namespace KNTyArch.Runtime
{
    /// <summary>ViewDataの保管庫</summary>
    public static class ViewDataStorage
    {
        /// <summary>IDとデータの保管場所の対応表</summary>
        static readonly Dictionary<int, ViewDataBase> _storage = new();
        /// <summary>Definitionのデータ型とその生成方法の対応表</summary>
        static readonly Dictionary<Type, Func<ViewDataBase>> _viewDataGenerateDict = new();
        /// <summary>インターフェースの倉庫</summary>
        static readonly InterfaceIndex<ViewDataBase> _interfaceIndex = new();

        /// <summary>
        /// DefinitionのリストからRuntimeの生成方法を受け取り対応表を作成するメソッド
        /// </summary>
        /// <param name="definitionCollection">Definitionのリスト</param>
        public static void SetRuntimeGenerating(DefinitionCollection definitionCollection)
        {
            var list = definitionCollection.definitionList;
            foreach (var definition in list)
            {
                _viewDataGenerateDict[definition.GetType()] = definition.CreateViewData;
            }
        }

        /// <summary>
        /// IDとデータを対応させて登録するメソッド
        /// </summary>
        /// <param name="handle">ID</param>
        /// <returns>データを登録できたかどうか</returns>
        public static bool TryRegister(ModelHandle handle, Type type)
        {
            var id = handle.ID;
            if (!_storage.ContainsKey(id)) return false;
            var viewData = _viewDataGenerateDict[type]();
            _storage[id] = viewData;
            _interfaceIndex.Register(viewData);
            return true;
        }

        /// <summary>
        /// IDに対して指定のデータ型インスタンスを取得するメソッド
        /// </summary>
        /// <typeparam name="TViewData">取得したいインスタンスのデータ型</typeparam>
        /// <param name="handle">ID</param>
        /// <param name="viewData">取得したインスタンス</param>
        /// <returns>指定のデータ型インスタンスを取得できたかどうか</returns>
        public static bool TryGetModel<TViewData>(ModelHandle handle, out TViewData viewData)
            where TViewData : ViewDataBase
        {
            var id = handle.ID;
            viewData = null;
            if (!_storage.TryGetValue(id, out var r)) return false;
            if (r is not TViewData typed) return false;
            viewData = typed;
            return true;
        }

        /// <summary>
        /// 指定のインターフェースを継承しているインスタンスをすべて取得するメソッド
        /// </summary>
        /// <typeparam name="TInterface">取得したいインスタンスのデータ型</typeparam>
        /// <param name="list">取得したインスタンスのリスト</param>
        /// <returns>取得できたかどうか</returns>
        public static bool TryGetInterfaces<TInterface>(out List<TInterface> list) where TInterface : class
        {
            return _interfaceIndex.TryGet(out list);
        }

        /// <summary>
        /// IDに対応したデータを削除するメソッド
        /// </summary>
        /// <param name="handle">ID</param>
        /// <returns>削除できたかどうか</returns>
        public static bool TryUnregister(ModelHandle handle)
        {
            var id = handle.ID;
            if (!_storage.ContainsKey(id)) return false;
            var viewData = _storage[id];
            _interfaceIndex.Unregister(viewData);
            _storage.Remove(id);
            return true;
        }

        /// <summary>
        /// データをすべて削除するメソッド
        /// </summary>
        public static void Clear()
        {
            foreach (var v in _storage.Values)
            {
                (v as IDisposable)?.Dispose();
            }
            _storage.Clear();
            _interfaceIndex.Clear();
        }
    }
}

using System;
using System.Collections.Generic;

namespace KNTyArch.Runtime
{
    /// <summary>Runtimeの保管庫</summary>
    public static class RuntimeStorage
    {
        /// <summary>IDとデータの保管場所の対応表</summary>
        static readonly Dictionary<int, RuntimeBase> _storage = new();
        /// <summary>Definitionのデータ型とその生成方法の対応表</summary>
        static readonly Dictionary<Type, Func<RuntimeBase>> _runtimeGenerateDict = new();
        /// <summary>インターフェースの倉庫</summary>
        static readonly InterfaceIndex<RuntimeBase> _interfaceIndex = new();

        /// <summary>
        /// DefinitionのリストからRuntimeの生成方法を受け取り対応表を作成するメソッド
        /// </summary>
        /// <param name="definitionCollection">Definitionのリスト</param>
        public static void SetModelGenerating(DefinitionCollection definitionCollection)
        {
            var list = definitionCollection.definitionList;
            foreach (var definition in list)
            {
                _runtimeGenerateDict[definition.GetType()] = definition.CreateRuntime;
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
            var runtime = _runtimeGenerateDict[type]();
            _storage[id] = runtime;
            _interfaceIndex.Register(runtime);
            return true;
        }

        /// <summary>
        /// IDに対して指定のデータ型インスタンスを取得するメソッド
        /// </summary>
        /// <typeparam name="TRuntime">取得したいインスタンスのデータ型</typeparam>
        /// <param name="handle">ID</param>
        /// <param name="runtime">取得したインスタンス</param>
        /// <returns>指定のデータ型インスタンスを取得できたかどうか</returns>
        public static bool TryGetModel<TRuntime>(ModelHandle handle, out TRuntime runtime)
            where TRuntime : RuntimeBase
        {
            var id = handle.ID;
            runtime = null;
            if (!_storage.TryGetValue(id, out var r)) return false;
            if (r is not TRuntime typed) return false;
            runtime = typed;
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
            var runtime = _storage[id];
            _interfaceIndex.Unregister(runtime);
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

using System;
using System.Collections.Generic;

namespace KNTyArch.Runtime
{
    /// <summary>
    /// インターフェースを集めるクラス</summary>
    /// <typeparam name="T">インターフェースを調べるクラスのデータ型</typeparam>
    internal sealed class InterfaceIndex<T> where T : class
    {
        /// <summary>インターフェースとそれに属するクラスのインスタンスの対応表</summary>
        readonly Dictionary<Type, List<object>> _map = new();

        /// <summary>
        /// 辞書に登録するメソッド
        /// </summary>
        /// <param name="model">登録するインスタンス</param>
        public void Register(T model)
        {
            var interfaces = model.GetType().GetInterfaces();

            foreach (var iface in interfaces)
            {
                if (!_map.TryGetValue(iface, out var list))
                {
                    list = new List<object>();
                    _map[iface] = list;
                }
                list.Add(model);
            }
        }

        /// <summary>
        /// 指定のインターフェース型のインスタンスをすべて取得するメソッド
        /// </summary>
        /// <typeparam name="TInterface">取得したいインターフェースの型</typeparam>
        /// <param name="list">インターフェースのリスト</param>
        /// <returns>リストを取得できたかどうか</returns>
        public bool TryGet<TInterface>(out List<TInterface> list) where TInterface : class
        {
            if (_map.TryGetValue(typeof(TInterface), out var l))
            {
                list = new List<TInterface>(l.Count);

                foreach (var iface in l)
                {
                    if (iface is TInterface typed)
                    {
                        list.Add(typed);
                    }
                }
                return true;
            }

            list = null;
            return false;
        }

        /// <summary>
        /// データを削除するメソッド
        /// </summary>
        /// <param name="model">削除するデータ</param>
        public void Unregister(T model)
        {
            var interfaces = model.GetType().GetInterfaces();

            foreach (var iface in interfaces)
            {
                if (_map.TryGetValue(iface, out var list))
                {
                    list.Remove(iface);
                }
            }
        }

        /// <summary>
        /// 登録してあるデータをすべて削除するメソッド
        /// </summary>
        public void Clear()
        {
            _map.Clear();
        }
    }
}

using System;
using System.Collections.Generic;

namespace KNTyArch.Runtime
{
    internal sealed class InterfaceIndex<T> where T : class
    {
        readonly Dictionary<Type, List<object>> _map = new();

        public void Register(T runtime)
        {
            var interfaces = runtime.GetType().GetInterfaces();

            foreach (var iface in interfaces)
            {
                if (!_map.TryGetValue(iface, out var list))
                {
                    list = new List<object>();
                    _map[iface] = list;
                }
                list.Add(runtime);
            }
        }

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

        public void Unregister(T runtime)
        {
            var interfaces = runtime.GetType().GetInterfaces();

            foreach (var iface in interfaces)
            {
                if (_map.TryGetValue(iface, out var list))
                {
                    list.Remove(iface);
                }
            }
        }

        public void Clear()
        {
            _map.Clear();
        }
    }
}

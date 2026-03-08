using System;
using System.Collections.Generic;

namespace KNTyArch.Runtime
{
    public static class EventHub
    {
        static readonly Dictionary<Type, List<Delegate>> _subscribers = new();
        static readonly Dictionary<object, List<IDisposable>> _ownerMap = new();

        public static void Publish<TEvent>(TEvent e) where TEvent : struct, IToken
        {
            var type = typeof(TEvent);
            if (!_subscribers.TryGetValue(type, out var list)) return;

            var handlers = list.ToArray();
            foreach (var handler in handlers)
            {
                ((Action<TEvent>)handler)(e);
            }
        }

        public static IDisposable Subscribe<TEvent>(object owner, Action<TEvent> handler) where TEvent : struct, IToken
        {
            var type = typeof(TEvent);
            if (!_subscribers.TryGetValue(type, out var list))
            {
                list = new List<Delegate>();
                _subscribers[type] = list;
            }

            list.Add(handler);

            var subscription = new Subscription(() =>
            {
                if (_subscribers.TryGetValue(type, out var l))
                {
                    l.Remove(handler);
                    if (l.Count == 0)
                        _subscribers.Remove(type);
                }
            });
            if (!_ownerMap.TryGetValue(owner, out var map))
            {
                map = new List<IDisposable>();
                _ownerMap[owner] = map;
            }

            map.Add(subscription);

            return subscription;
        }

        public static void Unsubscribe(object owner)
        {
            if (!_ownerMap.TryGetValue(owner, out var map)) return;
            foreach (var subscription in map)
            {
                subscription.Dispose();
            }
            _ownerMap.Remove(owner);
        }

        public static void Clear()
        {
            _subscribers.Clear();
            _ownerMap.Clear();
        }

        public static int GetSubscriberCount<TEvent>() where TEvent : struct, IToken
        {
            var type = typeof(TEvent);
            if (_subscribers.TryGetValue(type, out var list))
                return list.Count;
            return 0;
        }

        private sealed class Subscription : IDisposable
        {
            readonly Action _dispose;
            bool _disposed;

            public Subscription(Action dispose)
            {
                _dispose = dispose;
            }

            public void Dispose()
            {
                if (_disposed) return;
                _dispose();
                _disposed = true;
            }
        }
    }
}
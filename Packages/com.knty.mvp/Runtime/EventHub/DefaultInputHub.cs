using System;
using System.Collections.Generic;

namespace KNTy.MVP.Runtime
{
    public sealed class DefaultInputHub : IEventHub
    {
        readonly Dictionary<Type, List<Delegate>> _subscribers = new();

        public void Publish<TEvent>(TEvent e)
        {
            var type = typeof(TEvent);
            if (!_subscribers.TryGetValue(type, out var list)) return;

            var handlers = list.ToArray();
            foreach (var handler in handlers)
            {
                ((Action<TEvent>)handler)(e);
            }
        }

        public IDisposable Subscribe<TEvent>(Action<TEvent> handler)
        {
            var type = typeof(TEvent);
            if (!_subscribers.TryGetValue(type, out var list))
            {
                list = new List<Delegate>();
                _subscribers[type] = list;
            }

            list.Add(handler);

            return new Subscription(() => list.Remove(handler));
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

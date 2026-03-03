#if UNITY_EDITOR

namespace KNTyArch.Editor
{
    internal static class EventHubTemplate
    {
        internal static string EventHub(string name) =>
$@"using KNTyArch.Runtime;
using System;
using System.Collections.Generic;

public sealed class {name}EventHub : IEventHub
{{
    readonly Dictionary<Type, List<Delegate>> _subscribers = new();

    public void Publish<TEvent>(TEvent e) where TEvent : IToken
    {{
        var type = typeof(TEvent);
        if (!_subscribers.TryGetValue(type, out var list)) return;

        var handlers = list.ToArray();
        foreach (var handler in handlers)
        {{
            ((Action<TEvent>)handler)(e);
        }}
    }}

    public IDisposable Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IToken
    {{
        var type = typeof(TEvent);
        if (!_subscribers.TryGetValue(type, out var list))
        {{
            list = new List<Delegate>();
            _subscribers[type] = list;
        }}

        list.Add(handler);

        return new Subscription(() => list.Remove(handler));
    }}

    private sealed class Subscription : IDisposable
    {{
        readonly Action _dispose;
        bool _disposed;

        public Subscription(Action dispose)
        {{
            _dispose = dispose;
        }}

        public void Dispose()
        {{
            if (_disposed) return;
            _dispose();
            _disposed = true;
        }}
    }}
}}";
    }
}
#endif
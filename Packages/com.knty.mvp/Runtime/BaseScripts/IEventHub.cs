using System;

namespace KNTyArch.Runtime
{
    public interface IEventHub
    {
        void Publish<TEvent>(TEvent e) where TEvent : IToken;
        IDisposable Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IToken;
    }
}

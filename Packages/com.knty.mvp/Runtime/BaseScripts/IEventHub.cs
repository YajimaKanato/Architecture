using System;

namespace KNTy.MVP.Runtime
{
    public interface IEventHub
    {
        void Publish<TEvent>(TEvent e);
        IDisposable Subscribe<TEvent>(Action<TEvent> handler);
    }
}

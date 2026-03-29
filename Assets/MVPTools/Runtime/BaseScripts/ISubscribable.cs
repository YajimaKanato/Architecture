using System;

namespace MVPTools.Runtime
{
    public interface ISubscribable : IDisposable
    {
        void Subscribe();
        void Unsubscribe();
    }
}

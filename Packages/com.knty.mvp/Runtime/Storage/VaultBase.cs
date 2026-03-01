using System;
using System.Collections.Generic;

namespace KNTy.MVP.Runtime
{
    public abstract class VaultBase<T> : IVault
    {
        protected readonly Dictionary<int, T> _vault = new();

        public abstract bool TryRegister(int id, T runtimeModel);

        public bool TryGetModel(int id, out T runtimeModel)
        {
            return _vault.TryGetValue(id, out runtimeModel);
        }

        public bool TryUnregister(int id)
        {
            if (!_vault.TryGetValue(id, out T runtimeModel)) return false;
            (runtimeModel as IDisposable)?.Dispose();
            _vault.Remove(id);
            return true;
        }

        public virtual void Dispose()
        {
            _vault.Clear();
        }
    }

    public interface IVault : IDisposable { }
}

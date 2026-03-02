using System;
using System.Collections.Generic;

namespace KNTyArch.Runtime
{
    public class VaultBase<T> : IDisposable where T : class, IDisposable
    {
        protected readonly Dictionary<ID, T> _vault = new();

        public bool TryRegister(ID id, T model)
        {
            return _vault.TryAdd(id, model);
        }

        public bool TryGetModel(ID id, out T model)
        {
            return _vault.TryGetValue(id, out model);
        }

        public bool TryUnregister(ID id)
        {
            if (!_vault.TryGetValue(id, out T model)) return false;
            model.Dispose();
            _vault.Remove(id);
            return true;
        }

        public void Dispose()
        {
            foreach (var vault in _vault.Values)
            {
                vault.Dispose();
            }
            _vault.Clear();
        }
    }

    public interface IVault : IDisposable { }
}

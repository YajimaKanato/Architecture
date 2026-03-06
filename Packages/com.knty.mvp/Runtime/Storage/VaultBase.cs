using System;
using System.Collections.Generic;

namespace KNTyArch.Runtime
{
    public class VaultBase<T> : IDisposable where T : class, IDisposable
    {
        protected readonly Dictionary<string, T> _vault = new();

        public bool TryRegister(string id, T model)
        {
            return _vault.TryAdd(id, model);
        }

        public bool TryGetModel(string id, out T model)
        {
            return _vault.TryGetValue(id, out model);
        }

        public bool TryUnregister(string id)
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

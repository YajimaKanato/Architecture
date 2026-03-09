using System;
using System.Collections.Generic;

namespace KNTyArch.Runtime
{
    internal sealed class VaultBase<T> : IDisposable where T : class, IDisposable
    {
        readonly Dictionary<int, T> _vault = new();

        internal bool TryRegister(int id, T model)
        {
            return _vault.TryAdd(id, model);
        }

        internal bool TryGetModel(int id, out T model)
        {
            return _vault.TryGetValue(id, out model);
        }

        internal bool TryUnregister(int id)
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

    internal interface IVault : IDisposable { }
}

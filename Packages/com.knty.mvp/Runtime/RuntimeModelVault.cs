using System;
using System.Collections.Generic;

namespace KNTy.MVP.Runtime
{
    internal sealed class RuntimeModelVault<TRuntimeModel> : IRuntimeModelVault where TRuntimeModel : RuntimeModelBase
    {
        readonly Dictionary<int, TRuntimeModel> _vault = new();

        public bool TryRegister(int id, TRuntimeModel runtimeModel)
        {
            return _vault.TryAdd(id, runtimeModel);
        }

        public bool TryGetRuntimeModel(int id, out TRuntimeModel runtimeModel)
        {
            return _vault.TryGetValue(id, out runtimeModel);
        }

        public bool TryUnregister(int id)
        {
            if (!_vault.TryGetValue(id, out TRuntimeModel runtimeModel)) return false;
            (runtimeModel as IDisposable)?.Dispose();
            _vault.Remove(id);
            return true;
        }

        public void Dispose()
        {
            foreach (var runtimeModel in _vault.Values)
            {
                (runtimeModel as IDisposable)?.Dispose();
            }
            _vault.Clear();
        }
    }

    internal interface IRuntimeModelVault : IDisposable { }
}

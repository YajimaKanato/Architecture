using System;

namespace KNTy.MVP.Runtime
{
    internal sealed class RuntimeModelVault<TRuntimeModel> : VaultBase<TRuntimeModel> where TRuntimeModel : RuntimeModelBase
    {
        public override bool TryRegister(int id, TRuntimeModel runtimeModel)
        {
            return _vault.TryAdd(id, runtimeModel);
        }

        public override void Dispose()
        {
            foreach (var runtimeModel in _vault.Values)
            {
                (runtimeModel as IDisposable)?.Dispose();
            }
            base.Dispose();
        }
    }
}

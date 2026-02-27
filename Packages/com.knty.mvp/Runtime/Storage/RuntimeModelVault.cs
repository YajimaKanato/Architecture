using System;

namespace KNTy.MVP.Runtime
{
    internal sealed class RuntimeModelVault<TRuntimeModel> : VaultBase<TRuntimeModel> where TRuntimeModel : RuntimeModelBase
    {
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

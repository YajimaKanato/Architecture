namespace KNTy.MVP.Runtime
{
    public sealed class RuntimeModelStorage : StorageBase<RuntimeModelBase>
    {
        protected override IVault CreateVault<TRuntimeModel>()
        {
            return new RuntimeModelVault<TRuntimeModel>();
        }
    }
}

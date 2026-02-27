namespace KNTy.MVP.Runtime
{
    public sealed class ViewModelStorage : StorageBase<IViewModel>
    {
        protected override IVault CreateVault<TViewModel>()
        {
            return new ViewModelVault<TViewModel>();
        }
    }
}

namespace KNTy.MVP.Runtime
{
    internal sealed class ViewModelVault<TViewModel> : VaultBase<TViewModel> where TViewModel : struct, IViewModel
    {
        public override bool TryRegister(int id, TViewModel runtimeModel)
        {
            _vault[id] = runtimeModel;
            return true;
        }
    }
}

namespace KNTy.MVP.Runtime
{
    public interface IInitialize
    {
        string DebugLabel { get; }
        void Initialize();
    }
}

namespace KNTy.MVP.Runtime
{
    public class RuntimeModelBase : IRuntimeModel
    {
        public virtual string DebugLabel => GetType().Name;

        public virtual void Initialize()
        {

        }

        public virtual void Dispose()
        {

        }
    }
}

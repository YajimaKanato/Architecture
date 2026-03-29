using UnityEngine;

namespace MVPTools.Runtime
{
    public interface IModel<T>
    {
        T CreateRuntime();   
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "ModelBase", menuName = "Scriptable Objects/ModelBase")]
public abstract class ModelBase<T> : ScriptableObject where T: IRuntime
{
    public abstract T CreateRuntimeModel();
}

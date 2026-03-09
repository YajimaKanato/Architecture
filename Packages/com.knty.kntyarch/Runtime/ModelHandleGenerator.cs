using UnityEngine;

namespace KNTyArch.Runtime
{
    public static class ModelHandleGenerator
    {
        static int _id;

        public static ModelHandle<TDefinition> GenerateModelHandle<TDefinition>() where TDefinition : DefinitionBase
        {
            return new ModelHandle<TDefinition>(_id++);
        }
    }
}

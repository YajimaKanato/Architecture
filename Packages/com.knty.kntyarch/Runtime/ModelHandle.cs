using System;

namespace KNTyArch.Runtime
{
    /// <summary>View、InteractiveViewとModelsを連携させる構造体</summary>
    /// <typeparam name="TDefinition">Definitionのデータ型</typeparam>
    public readonly struct ModelHandle<TDefinition> : IEquatable<ModelHandle<TDefinition>> where TDefinition : DefinitionBase
    {
        public readonly int ID;
        public ModelHandle(int id)
        {
            ID = id;
        }

        public bool Equals(ModelHandle<TDefinition> other)
        {
            return ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            return obj is ModelHandle<TDefinition> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public static bool operator ==(ModelHandle<TDefinition> left,ModelHandle<TDefinition> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ModelHandle<TDefinition> left, ModelHandle<TDefinition> right)
        {
            return !left.Equals(right);
        }
    }
}

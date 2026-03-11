using System;

namespace KNTyArch.Runtime
{
    /// <summary>View、InteractiveViewとModelsを連携させる構造体</summary>
    public readonly struct ModelHandle : IEquatable<ModelHandle>
    {
        public readonly int ID;
        public ModelHandle(int id)
        {
            ID = id;
        }

        public bool Equals(ModelHandle other)
        {
            return ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            return obj is ModelHandle other && Equals(other);
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public static bool operator ==(ModelHandle left,ModelHandle right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ModelHandle left, ModelHandle right)
        {
            return !left.Equals(right);
        }
    }
}

using Microsoft.Xna.Framework;

namespace Insight.Engine
{
    public class Transform : Component
    {
        public Vector3 Position;
        public Vector3 Rotation;

        public Transform(GameObject self) : base (self)
        {
            Rotation = Vector3.Zero;
            Position = Vector3.Zero;
            Name = "Transform";
        }
        public Transform(GameObject self, Vector3 pos) : base(self)
        {
            Rotation = Vector3.Zero;
            Position = pos;
            Name = "Transform";
        }

    }
}
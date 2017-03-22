using Insight.Engine.Components;
using Microsoft.Xna.Framework;

namespace Insight.Engine
{
    public class Transform : Component
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Quaternion quaterion;
        public Vector3 origin;

        public Transform(GameObject self) : base (self)
        {
            Rotation = Vector3.Zero;
            Position = Vector3.Zero;
            quaterion = new Quaternion();
            Name = "Transform";
        }
        public Transform(GameObject self, Vector3 pos) : base(self)
        {
            Rotation = Vector3.Zero;
            Position = pos;
            quaterion = new Quaternion();
            Name = "Transform";
        }

        public void Rotate(Vector3 axis, float angle)
        {
            //quaterion.W;
            quaterion = Quaternion.CreateFromAxisAngle(axis, angle);
        }

    }
}
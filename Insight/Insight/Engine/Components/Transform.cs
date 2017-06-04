using Insight.Engine.Components;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Insight.Engine
{
    public class Transform : Component
    {
        public Vector3 Position;
        public Vector3 prevPosition { get; private set; }
        public Vector3 Rotation;
        public Quaternion quaterion;
        public Vector3 origin;

        public Vector3 forward;

        public Transform(GameObject self) : base (self)
        {
            Rotation = Vector3.Zero;
            Position = Vector3.Zero;
            quaterion = Quaternion.Identity;
            forward = Vector3.Transform(Vector3.Forward, Matrix.CreateFromAxisAngle(Vector3.UnitX, Rotation.X) * Matrix.CreateFromAxisAngle(Vector3.UnitY, Rotation.Y) * Matrix.CreateFromAxisAngle(Vector3.UnitZ, Rotation.Z));
            Name = "Transform";
        }
        public Transform(GameObject self, Vector3 pos) : base(self)
        {
            Rotation = Vector3.Zero;
            Position = pos;
            quaterion = Quaternion.Identity;
            forward = Vector3.Transform(Vector3.Forward, Matrix.CreateFromAxisAngle(Vector3.UnitX, Rotation.X) * Matrix.CreateFromAxisAngle(Vector3.UnitY, Rotation.Y) * Matrix.CreateFromAxisAngle(Vector3.UnitZ, Rotation.Z));
            Name = "Transform";
        }

        public override void Update()
        {
            forward = Vector3.Transform(Vector3.Forward, Matrix.CreateFromAxisAngle(Vector3.UnitX, Rotation.X) * Matrix.CreateFromAxisAngle(Vector3.UnitY, Rotation.Y) * Matrix.CreateFromAxisAngle(Vector3.UnitZ, Rotation.Z));
            base.Update();
        }

        public void Rotate(Vector3 axis, float angle)
        {
            //quaterion.W;
            quaterion *= Quaternion.CreateFromAxisAngle(axis, angle);
            //Rotation =
            //Debug.WriteLine(quaterion);
        }

        public void Move(Vector3 axis, float speed)
        {
            prevPosition = Position;
            if(axis == Vector3.UnitX)
            {
                Position.X += speed;
            }
            if(axis == Vector3.UnitY)
            {
                Position.Y += speed;
            }
            if(axis == Vector3.UnitZ)
            {
                Position.Z += speed;
            }
        }

    }
}
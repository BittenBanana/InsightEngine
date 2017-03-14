using Microsoft.Xna.Framework;

namespace Insight.Engine
{
    public class Transform : Component
    {
        GameObject self;
        //public Matrix rotation { get; set; }
        //public Vector3 Position {
        //    get
        //    {
        //        return Matrix.Invert(position).Translation;
        //    }
        //    set
        //    {
        //        position = Matrix.CreateTranslation(value);
        //    }
        //}
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

        public override void Update()
        {
            base.Update();
        }
    }
}
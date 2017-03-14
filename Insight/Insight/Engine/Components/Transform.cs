using Microsoft.Xna.Framework;

namespace Insight.Engine
{
    public class Transform : Component
    {
        GameObject self;
        public Matrix position { get; set; }
        public Matrix rotation { get; set; }
        public Transform(GameObject self) : base (self)
        {
            this.self = self;
            Name = "Transform";
        }

        public override void Uprade()
        {
            base.Uprade();
        }
    }
}
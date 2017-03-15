using Insight.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine
{
    public class Camera : Component
    {
        public Matrix projection { get; private set; }
        public Matrix view { get;  set; }
        public Vector3 Position;

        public Camera(GameObject gameObject) : base (gameObject)
        {
            projection = MainScene.projection;
            Position = new Vector3(gameObject.Transform.Position.X, gameObject.Transform.Position.Y + 7, gameObject.Transform.Position.Z - 15);
            view = Matrix.CreateLookAt(Position, Vector3.Forward, Vector3.Up);
        }

        public override void Update()
        {

            base.Update();
        }
        
    }
}

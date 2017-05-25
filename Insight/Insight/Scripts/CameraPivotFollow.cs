using Insight.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Insight.Scripts
{
    class CameraPivotFollow : BaseScript
    {
        public GameObject player;
        private MouseState s;
        private Vector2 lastMousePos;

        public CameraPivotFollow(GameObject gameObject) : base(gameObject)
        {
            lastMousePos = Mouse.GetState().Position.ToVector2();
        }

        public override void Update()
        {
            gameObject.Transform.Position = new Vector3(player.Transform.Position.X, player.Transform.Position.Y + 5, player.Transform.Position.Z);
            gameObject.Transform.Rotation.Y = player.Transform.Rotation.Y;

            s = Mouse.GetState();

            if (s.Position.ToVector2().Y < lastMousePos.Y && gameObject.Transform.Rotation.X <= 0.99f)
            {
                gameObject.Transform.Rotation.X += gameObject.rotationSpeed * Math.Abs(s.Position.Y - lastMousePos.Y);
                
            }

            if (s.Position.ToVector2().Y > lastMousePos.Y && gameObject.Transform.Rotation.X >= -0.99f)
            {
                gameObject.Transform.Rotation.X -= gameObject.rotationSpeed * Math.Abs(s.Position.Y - lastMousePos.Y);
            }
            gameObject.rotationSpeed = .005f;
            lastMousePos = s.Position.ToVector2();

            

            base.Update();
        }
    }
}

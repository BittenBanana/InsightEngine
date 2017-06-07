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
            gameObject.Transform.Position = new Vector3(player.Transform.Position.X, player.Transform.Position.Y + 3.5f, player.Transform.Position.Z);
            gameObject.Transform.Rotation.Y = player.Transform.Rotation.Y;

            s = Mouse.GetState();

            if (s.Position.ToVector2().Y < SceneManager.Instance.device.GraphicsDevice.Viewport.Height / 2  && gameObject.Transform.Rotation.X <= 0.44444444444 * Math.PI)
            {
                gameObject.Transform.Rotation.X += gameObject.rotationSpeed * Math.Abs(s.Position.Y - lastMousePos.Y);
                
            }

            if (s.Position.ToVector2().Y > SceneManager.Instance.device.GraphicsDevice.Viewport.Height / 2 && gameObject.Transform.Rotation.X >= -0.44444444444 * Math.PI)
            {
                gameObject.Transform.Rotation.X -= gameObject.rotationSpeed * Math.Abs(s.Position.Y - lastMousePos.Y);
            }
            gameObject.rotationSpeed = .01f;
            lastMousePos = s.Position.ToVector2();

            Mouse.SetPosition(s.Position.X, SceneManager.Instance.device.GraphicsDevice.Viewport.Height / 2);

            base.Update();
        }
    }
}

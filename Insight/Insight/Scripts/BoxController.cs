using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework.Input;

namespace Insight.Scripts
{
    class BoxController : BaseScript
    {
        public BoxController(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Update()
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Left))
            {
                gameObject.Transform.Rotation.Y += .05f;
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                gameObject.Transform.Rotation.Y -= .05f;
                //gameObject.Transform.Rotate()
            }
            if (keyState.IsKeyDown(Keys.Up))
            {
                gameObject.Transform.Position.X += gameObject.velocityX;
                gameObject.Transform.Position.Z += gameObject.velocityZ;
            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                gameObject.Transform.Position.X -= gameObject.velocityX;
                gameObject.Transform.Position.Z -= gameObject.velocityZ;
            }
            base.Update();
        }
    }
}

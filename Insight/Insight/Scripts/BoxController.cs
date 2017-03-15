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
            }
            if (keyState.IsKeyDown(Keys.Up))
            {
                gameObject.Transform.Position.X += 1f * (float)Math.Sin(gameObject.Transform.Rotation.Y);
                gameObject.Transform.Position.Z += 1f * (float)Math.Cos(gameObject.Transform.Rotation.Y);
            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                gameObject.Transform.Position.X -= 1f * (float)Math.Sin(gameObject.Transform.Rotation.Y);
                gameObject.Transform.Position.Z -= 1f * (float)Math.Cos(gameObject.Transform.Rotation.Y);
            }
            base.Update();
        }
    }
}

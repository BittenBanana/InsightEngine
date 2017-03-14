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
        public Matrix projection;
        public Matrix view;
        public Vector3 camPos;

        public Camera(GameObject gameObject) : base (gameObject)
        {
            camPos = new Vector3(gameObject.pos.X, gameObject.pos.Y + 7, gameObject.pos.Z - 15);
            view = Matrix.CreateLookAt(camPos, Vector3.Forward, Vector3.Up);
        }

        public override void Update()
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Left))
            {
                gameObject.rotation.Y += .05f;
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                gameObject.rotation.Y -= .05f;
            }
            if (keyState.IsKeyDown(Keys.Up))
            {
                gameObject.pos.X += 1f * (float)Math.Sin(gameObject.rotation.Y);
                gameObject.pos.Z += 1f * (float)Math.Cos(gameObject.rotation.Y);
            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                gameObject.pos.X -= 1f * (float)Math.Sin(gameObject.rotation.Y);
                gameObject.pos.Z -= 1f * (float)Math.Cos(gameObject.rotation.Y);
            }

            //camPos.X = gameObject.pos.X - 15 * (float)Math.Sin(gameObject.rotation.Y);
            //camPos.Z = gameObject.pos.Z - 15 * (float)Math.Cos(gameObject.rotation.Y);
            //view = Matrix.CreateLookAt(camPos, gameObject.pos, Vector3.Up);
            base.Update();
        }

        public void InitCamera(Matrix projection)
        {
            this.projection = projection;
        }
    }
}

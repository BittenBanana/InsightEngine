using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Insight.Scripts
{
    class ThirdPersonCamera : BaseScript
    {
        MouseState originalMouseState;
        float Horizontal = MathHelper.PiOver2;
        float Vertical = -MathHelper.Pi / 10.0f;

        GraphicsDevice device;
        public ThirdPersonCamera(GameObject gameObject) : base(gameObject)
        {
            device = SceneManager.Instance.device.GraphicsDevice;
            Mouse.SetPosition(device.Viewport.Width / 2,
                device.Viewport.Height / 2);
            originalMouseState = Mouse.GetState();
        }

        public override void Update()
        {
            float prevHorizontal = 0;
            MouseState currentMouseState = Mouse.GetState();
            if(currentMouseState.Y != originalMouseState.Y)
            {
                //float xDifference = currentMouseState.X - originalMouseState.X;
                float yDifference = currentMouseState.Y - originalMouseState.Y;

                //Vertical += 0.05f * xDifference;
                Horizontal += yDifference * 0.1f;

                //if(device != null)
                //    Mouse.SetPosition(device.Viewport.Width / 2,
                //                      device.Viewport.Height / 2);
                
                gameObject.Transform.Rotation.Y= Horizontal;
                originalMouseState = currentMouseState;
            }


        }
    }
}

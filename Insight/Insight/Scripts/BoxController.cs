using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Insight.Engine.Components;

namespace Insight.Scripts
{
    class BoxController : BaseScript
    {
        public BoxController(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Update()
        {
            gameObject.IsMoving = false;
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Left))
            {
                gameObject.Transform.Rotation.Y += gameObject.rotationSpeed;

                gameObject.Transform.Rotate(Vector3.UnitY, gameObject.rotationSpeed);
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                gameObject.Transform.Rotation.Y -= gameObject.rotationSpeed;
                gameObject.Transform.Rotate(Vector3.UnitY, -gameObject.rotationSpeed);
            }
            if (keyState.IsKeyDown(Keys.Up))
            {
                gameObject.Transform.Position.X += gameObject.velocityX;
                gameObject.Transform.Position.Z += gameObject.velocityZ;
                gameObject.Forward = true;
                gameObject.Backward = false;
                gameObject.IsMoving = true;
            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                gameObject.Transform.Position.X -= gameObject.velocityX;
                gameObject.Transform.Position.Z -= gameObject.velocityZ;
                gameObject.Forward = false;
                gameObject.Backward = true;
                gameObject.IsMoving = true;
            }
            if (keyState.IsKeyDown(Keys.Space) && gameObject.GetComponent<Rigidbody>().isGrounded)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 75, 0));
            }

            gameObject.rotationSpeed = .05f;
            base.Update();
        }

        public override void OnTriggerEnter(object source, CollisionEventArgs args)
        {
            Debug.WriteLine("On trigger enter");
        }

        public override void OnTriggerStay(object source, CollisionEventArgs args)
        {
            //Debug.WriteLine("On trigger stay");
        }

        public override void OnTriggerExit(object source, CollisionEventArgs args)
        {
            Debug.WriteLine("On trigger exit");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;
using Insight.Scenes;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using Insight.Engine.Components;

namespace Insight.Scripts
{
    class RaycastTest : BaseScript
    {
        Physics.RaycastHit hit;
       
        public RaycastTest(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Update()
        {
            MouseState ms = Mouse.GetState();

            Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, gameObject.Transform.Rotation.X) *
                Quaternion.CreateFromAxisAngle(Vector3.UnitY, gameObject.Transform.Rotation.Y) *
                Quaternion.CreateFromAxisAngle(Vector3.UnitZ, gameObject.Transform.Rotation.Z);

            Vector3 direction = Vector3.Transform(Vector3.Backward, rotation);


            if (ms.LeftButton == ButtonState.Pressed)
            if(Physics.Raycast(gameObject.Transform.Position, direction, out hit))
            {
                
                Debug.WriteLine("Hit!" + " " + hit.collider.gameObject + " " + hit.distance);
            }
            //base.Update();
        }

        public override void Draw(Camera cam)
        {

            base.Draw(cam);
        }
    }
}

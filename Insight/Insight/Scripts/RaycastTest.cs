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
           
            if(ms.LeftButton == ButtonState.Pressed)
            if(Physics.Raycast(gameObject.Transform.Position, SceneManager.Instance.GetGameObjectsFromCurrentScene().Find(go => go != gameObject).Transform.Position, out hit))
            {
                
                Debug.WriteLine("Hit!" + hit.distance);
            }
            //base.Update();
        }

        public override void Draw(Camera cam)
        {

            base.Draw(cam);
        }
    }
}

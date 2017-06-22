using Insight.Engine;
using Insight.Engine.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Scripts
{
    class LowerStairsTriggerController : BaseScript
    {
        public LowerStairsTriggerController(GameObject gameObject) : base(gameObject)
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnTriggerEnter(object source, CollisionEventArgs args)
        {
            if (args.GameObject.physicLayer == Layer.Player)
            {
                Debug.WriteLine("stairs trigger");

                if (args.GameObject.GetComponent<Rigidbody>().useGravity == false)
                {
                    args.GameObject.GetComponent<Rigidbody>().useGravity = true;
                }
                else
                {
                    args.GameObject.GetComponent<Rigidbody>().useGravity = false;
                    args.GameObject.Transform.Position.Y = -4f;
                }

            }
        }

        public override void OnTriggerStay(object source, CollisionEventArgs args)
        {
            if (args.GameObject.physicLayer == Layer.Player)
            {
            }


        }

        public override void OnTriggerExit(object source, CollisionEventArgs args)
        {
            if (args.GameObject.physicLayer == Layer.Player)
            {

            }

        }
    }
}

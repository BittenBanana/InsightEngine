using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;

namespace Insight.Scripts
{
    class EnemySight : BaseScript
    {
        public Transform followTransform { get; set; }
        public float fovAngle { get; set; }
        public EnemySight(GameObject gameObject) : base(gameObject)
        {
            fovAngle = 110f;
        }

        public override void Update()
        {
            gameObject.Transform = followTransform;
            base.Update();
        }

        public override void OnTriggerStay(object source, CollisionEventArgs args)
        {
            //Debug.WriteLine("OnTriggerStayEnemy");
            if (args.GameObject.physicLayer == Layer.Player)
            {
                Vector3 direction = args.GameObject.Transform.Position - gameObject.Transform.Position;
                float angle = (float)Math.Acos(Vector3.Dot(gameObject.Transform.forward, direction));

                if (angle < fovAngle * 0.5f)
                {
                    Debug.WriteLine("Player InSight");
                }
            }

        }
    }
}

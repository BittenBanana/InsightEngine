using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;

namespace Insight.Scripts
{
    class EnemySight : BaseScript
    {
        public Transform followTransform { get; set; }
        public float fovAngle { get; set; }
        public float reactionTime { get; set; }
        private float timer;

        public EnemySight(GameObject gameObject) : base(gameObject)
        {
            fovAngle = DegreeToRadian(110f);
            reactionTime = 0.25f;
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
                direction.Normalize();
                float angle = (float)Math.Acos(Vector3.Dot(gameObject.Transform.forward, direction));

                if (angle < fovAngle * 0.5f)
                {
                    if (timer >= reactionTime)
                    {
                        Physics.RaycastHit hit;
                        if (Physics.Raycast(gameObject.Transform.Position, direction, out hit))
                        {
                            if (hit.collider.gameObject.physicLayer == Layer.Player)
                            {
                                Debug.WriteLine("Player InSight");
                            }
                        }
                        
                        timer = 0;
                    }
                    timer += Time.deltaTime;
                }
            }
        }

        public override void OnTriggerExit(object source, CollisionEventArgs args)
        {
            timer = 0f;
        }

        private float DegreeToRadian(float degree)
        {
            return (float)(degree * Math.PI) / 180f;
        }
    }
}

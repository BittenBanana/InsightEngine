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

        private bool isOnTrigger;

        //public bool isPlayerSeen { get; private set; }
        //public bool isPlayerHeard { get; private set; }
        public GameObject player { get; private set; }

        public Vector3 lastSeenPosition { get; private set; }
        public Vector3 lastHeardPosition { get; private set; }

        public float detectionLevel { get; private set; }

        public EnemySight(GameObject gameObject) : base(gameObject)
        {
            fovAngle = DegreeToRadian(170f);
            reactionTime = 0.25f;

            foreach (GameObject item in SceneManager.Instance.GetGameObjectsFromCurrentScene())
            {
                if (item.physicLayer != Layer.Player) continue;
                player = item;
                break;
            }
        }

        public override void Update()
        {
            gameObject.Transform = followTransform;
            
            if(!isOnTrigger && detectionLevel > 0)
                detectionLevel -= Time.deltaTime * 0.1f;

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
                        if (Physics.Raycast(gameObject.Transform.Position + direction, direction, out hit))
                        {
                            if (hit.collider.gameObject.physicLayer == Layer.Player)
                            {
                                if (detectionLevel < 1)
                                    detectionLevel += Time.deltaTime * 2;
                                lastSeenPosition = player.Transform.Position;
                            }
                        }

                        timer = 0;
                    }
                    timer += Time.deltaTime;
                }
                if (detectionLevel < 1)
                    detectionLevel += Time.deltaTime * 0.25f;
                //isPlayerHeard = true;
                lastHeardPosition = player.Transform.Position;
                if (!isOnTrigger)
                    isOnTrigger = true;
            }
        }

        public override void OnTriggerExit(object source, CollisionEventArgs args)
        {
            //isPlayerHeard = false;
            //isPlayerSeen = false;
            isOnTrigger = false;
            timer = 0f;
        }

        private float DegreeToRadian(float degree)
        {
            return (float)(degree * Math.PI) / 180f;
        }
    }
}

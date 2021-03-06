﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Insight.Engine;
using Insight.Engine.Components;
using Insight.Scripts.EnemyStates;
using Microsoft.Xna.Framework;

namespace Insight.Scripts
{
    class EnemySight : BaseScript
    {
        public float fovAngle { get; set; }
        public float reactionTime { get; set; }
        private float timer;

        public bool isOnTrigger;

        //public bool isPlayerSeen { get; private set; }
        //public bool isPlayerHeard { get; private set; }
        public GameObject player { get; private set; }
        public GameObject enemy { get; set; }

        public Vector3 lastSeenPosition { get; private set; }
        public Vector3 lastHeardPosition { get; private set; }

        public float detectionLevel { get; private set; }

        private float radius;
        private float distance;

        public EnemySight(GameObject gameObject) : base(gameObject)
        {
            fovAngle = DegreeToRadian(170f);
            reactionTime = 0.25f;

            radius = gameObject.GetComponent<SphereCollider>().GetCompleteBoundingSphere().Radius * gameObject.GetComponent<Renderer>().GetScale();

            foreach (GameObject item in SceneManager.Instance.GetGameObjectsFromCurrentScene())
            {
                if (item.physicLayer != Layer.Player) continue;
                player = item;
                break;
            }
        }

        public override void Update()
        {
            gameObject.Transform = enemy.Transform;

            if ((!isOnTrigger && detectionLevel > 0) || !enemy.GetComponent<EnemyAI>().detect)
                detectionLevel -= Time.deltaTime * 0.1f;

            base.Update();
        }

        public override void OnTriggerStay(object source, CollisionEventArgs args)
        {
            //Debug.WriteLine("OnTriggerStayEnemy");
            if (args.GameObject.physicLayer == Layer.Player && enemy.GetComponent<EnemyAI>().detect)
            {
                Vector3 direction = args.GameObject.Transform.Position - gameObject.Transform.Position;
                direction.Normalize();
                float angle = (float)Math.Acos(Vector3.Dot(gameObject.Transform.forward, direction));
                distance = EnemyWalkingSpots.getInstance()
                    .DistanceFromDestination(gameObject.Transform.Position, player.Transform.Position);

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
                                    detectionLevel += Time.deltaTime * 4 * (1 + (1 - distance / radius));
                                lastSeenPosition = player.Transform.Position;
                            }
                        }

                        timer = 0;
                    }
                    timer += Time.deltaTime;
                }
                if (player.GetComponent<BoxController>().mState == BoxController.MovementState.IsRunning)
                {
                    if (detectionLevel < 1)
                        detectionLevel += Time.deltaTime * 0.25f * (1 + (1 - distance / radius));
                    //isPlayerHeard = true;
                    lastHeardPosition = player.Transform.Position;
                }
                else if (distance < radius / 2)
                {
                    if (detectionLevel < 1)
                        detectionLevel += Time.deltaTime * 0.25f * (1 + (1 - distance / radius));
                    //isPlayerHeard = true;
                    lastHeardPosition = player.Transform.Position;
                }
                else
                {
                    if (detectionLevel > 0)
                        detectionLevel -= Time.deltaTime * 0.1f;
                }
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

﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Insight.Engine.Components;
using Microsoft.Xna.Framework;

namespace Insight.Scripts.EnemyStates
{
    class StandAndLookState : EnemyAIState
    {
        private float timer;

        private float delay;

        private bool left;

        private bool isRotationReset;

        public override void EnterState(EnemyAI enemy)
        {
            Debug.WriteLine("Enter Stand State");
            timer = 0;
            delay = 4;
        }

        public override void Execute(EnemyAI enemy)
        {
            if (EnemyWalkingSpots.getInstance()
                    .DistanceFromDestination(enemy.gameObject.Transform.Position, enemy.standPosition) < 0.1f)
            {
                if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 0)
                    enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(0,true);
                if (!isRotationReset)
                {
                    enemy.gameObject.Transform.Rotation = enemy.defaultRotation;
                    isRotationReset = true;
                }
                if (timer >= delay)
                {
                    if (timer >= delay + 1)
                    {
                        timer = 0;
                        if (left) left = false;
                        else left = true;
                    }
                    else
                    {
                        if (left)
                        {
                            enemy.gameObject.Transform.Rotation += new Vector3(0, 1, 0) * Time.deltaTime;
                           
                        }
                        else
                        {
                            enemy.gameObject.Transform.Rotation -= new Vector3(0, 1, 0) * Time.deltaTime;
                            
                        }
                    }

                }
                timer += Time.deltaTime;
            }
            else
            {
                if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 1)
                    enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(1,true);
                isRotationReset = false;
                EnemyWalkingSpots.getInstance().MoveGameObjectToDestination(enemy.gameObject, enemy.standPosition, 0.05f, 0.1f);
            }

            if (enemy.enemySight.detectionLevel > 0.9f)
            {
                enemy.ChangeState(new ChaseState());
            }
            else if (enemy.enemySight.detectionLevel > 0.6f && enemy.enemySight.detectionLevel <= 0.9f)
            {
                enemy.ChangeState(new CheckState());
            }
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit Stand State");
        }
    }
}

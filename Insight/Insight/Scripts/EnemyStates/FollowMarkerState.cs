﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;

namespace Insight.Scripts.EnemyStates
{
    class FollowMarkerState : EnemyAIState
    {
        private float timer;
        private float wait;

        public override void EnterState(EnemyAI enemy)
        {
            timer = 0;
            wait = 5;
            Debug.WriteLine("Enter Marker State");
        }

        public override void Execute(EnemyAI enemy)
        {
            if (enemy.markerPosition != null)
            {
                if (EnemyWalkingSpots.getInstance()
                        .DistanceFromDestination(enemy.gameObject.Transform.Position, (Vector3) enemy.markerPosition) >
                    0.1f)
                {
                    EnemyWalkingSpots.getInstance()
                        .MoveGameObjectToDestination(enemy.gameObject, (Vector3) enemy.markerPosition, 0.05f, 0.1f);
                }
                else
                {
                    if (timer >= wait)
                    {
                        enemy.ChangeState(enemy.previousState);
                    }
                    timer += Time.deltaTime;
                }
            }
            else
            {
                enemy.ChangeState(enemy.previousState);
            }
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit Marker State");
        }
    }
}
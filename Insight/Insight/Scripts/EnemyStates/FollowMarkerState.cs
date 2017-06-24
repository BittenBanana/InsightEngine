using System;
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
    class FollowMarkerState : EnemyAIState
    {
        private float timer;
        private float wait;

        public override void EnterState(EnemyAI enemy)
        {
            timer = 0;
            wait = 10;
            Debug.WriteLine("Enter Marker State");
            enemy.detect = false;
        }

        public override void Execute(EnemyAI enemy)
        {
            if (enemy.markerPosition != null)
            {
                if (EnemyWalkingSpots.getInstance()
                        .DistanceFromDestination(enemy.gameObject.Transform.Position, (Vector3) enemy.markerPosition) >
                    0.1f)
                {
                    if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 1)
                        enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(1);
                    EnemyWalkingSpots.getInstance()
                        .MoveGameObjectToDestination(enemy.gameObject, (Vector3) enemy.markerPosition, 0.05f, 0.1f);
                }
                else
                {
                    if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 0)
                        enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(0);
                    if (timer >= wait)
                    {
                        enemy.ChangeState(enemy.defaultState);
                    }
                    timer += Time.deltaTime;
                }
            }
            else
            {
                enemy.ChangeState(enemy.defaultState);
            }
        }

        public override void Exit(EnemyAI enemy)
        {
            enemy.detect = true;
            Debug.WriteLine("Exit Marker State");
        }
    }
}

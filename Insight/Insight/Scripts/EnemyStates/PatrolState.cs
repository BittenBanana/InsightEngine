using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;

namespace Insight.Scripts.EnemyStates
{
    class PatrolState : EnemyAIState
    {
        private Vector3 currentDestination;
        private int destIterator;

        private float timer;
        private float wait;

        public override void EnterState(EnemyAI enemy)
        {
            Debug.WriteLine("Enter Patrol State");
            destIterator = 0;
            currentDestination = enemy.patrolPositions[destIterator];
            timer = 0;
            wait = 5;
        }

        public override void Execute(EnemyAI enemy)
        {
            if (EnemyWalkingSpots.getInstance()
                    .DistanceFromDestination(enemy.gameObject.Transform.Position, currentDestination) > 0.1f)
            {
                EnemyWalkingSpots.getInstance()
                    .MoveGameObjectToDestination(enemy.gameObject, currentDestination, 0.05f, 0.1f);
            }
            else
            {
                if (timer >= wait)
                {
                    if (destIterator < enemy.patrolPositions.Count - 1)
                    {
                        destIterator++;
                    }
                    else
                    {
                        destIterator = 0;
                    }
                    currentDestination = enemy.patrolPositions[destIterator];
                    timer = 0;
                }
                timer += Time.deltaTime;
            }

            if (enemy.enemySight.detectionLevel > 0.9f)
            {
                enemy.ChangeState(new ChaseState());
            }
            else if (enemy.enemySight.detectionLevel > 0.75f && enemy.enemySight.detectionLevel <= 0.9f)
            {
                enemy.ChangeState(new CheckState());
            }
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit Patrol State");
        }
    }
}

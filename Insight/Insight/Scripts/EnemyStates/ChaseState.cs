using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Insight.Engine;

namespace Insight.Scripts.EnemyStates
{
    class ChaseState : EnemyAIState
    {
        private float timer;
        private float wait;
        private float shootDistance;

        public override void EnterState(EnemyAI enemy)
        {
            timer = 0;
            wait = 15;
            shootDistance = 5;
            Debug.WriteLine("Enter Chase State");
        }

        public override void Execute(EnemyAI enemy)
        {
            if (!enemy.enemySight.isPlayerSeen)
            {
                if (EnemyWalkingSpots.getInstance().DistanceFromDestination(enemy.gameObject.Transform.Position,
                        enemy.enemySight.lastSeenPosition) < 0.1f)
                {
                    if (timer >= wait)
                    {
                        if (enemy.enemySight.isPlayerHeard)
                            enemy.ChangeState(new CheckState());
                        else
                        {
                            enemy.ChangeState(enemy.defaultState);
                        }
                        timer = 0;
                    }
                    timer += Time.deltaTime;
                }
                else
                {
                    EnemyWalkingSpots.getInstance().MoveGameObjectToDestination(enemy.gameObject,
                        enemy.enemySight.lastSeenPosition, 0.05f, 0.1f);
                }

            }
            else if (EnemyWalkingSpots.getInstance().DistanceFromDestination(enemy.gameObject.Transform.Position, enemy.enemySight.lastSeenPosition) > 0.1f)
            {
                EnemyWalkingSpots.getInstance().MoveGameObjectToDestination(enemy.gameObject,
                    enemy.enemySight.lastSeenPosition, 0.05f, 0.1f);

                if (EnemyWalkingSpots.getInstance().DistanceFromDestination(enemy.gameObject.Transform.Position,
                        enemy.enemySight.player.Transform.Position) < shootDistance)
                {
                    enemy.ChangeState(new ShootState());
                }
            }

        }

        public override void Exit(EnemyAI enemy)
        {
            enemy.previousState = this;
            Debug.WriteLine("Exit Chase State");
        }
    }
}

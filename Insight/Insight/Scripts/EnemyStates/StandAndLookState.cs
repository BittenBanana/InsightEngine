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
                if (!isRotationReset)
                {
                    enemy.gameObject.Transform.Rotation = enemy.defaultRotation;
                    isRotationReset = true;
                }
                if (timer >= delay)
                {
                    if (timer >= 1.5f * delay)
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
                isRotationReset = false;
                EnemyWalkingSpots.getInstance().MoveGameObjectToDestination(enemy.gameObject, enemy.standPosition, 0.05f, 0.1f);
            }

            if (enemy.health <= 0)
            {
                enemy.ChangeState(new DeathState());
            }

            if (enemy.enemySight.isPlayerSeen)
            {
                enemy.ChangeState(new ChaseState());
            }
            else if (enemy.enemySight.isPlayerHeard)
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

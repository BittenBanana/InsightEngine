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

        public override void EnterState(EnemyAI enemy)
        {
            Debug.WriteLine("Enter Stand State");
            timer = 0;
            delay = 1;
        }

        public override void Execute(EnemyAI enemy)
        {
            if (timer >= delay)
            {
                if (timer >= 2 * delay)
                {
                    timer = 0;
                }
                else
                {
                    if (left)
                    {
                        enemy.gameObject.Transform.Rotation += new Vector3(0, 1, 0) * Time.deltaTime;
                        left = false;
                    }
                    else
                    {
                        enemy.gameObject.Transform.Rotation -= new Vector3(0, 1, 0) * Time.deltaTime;
                        left = true;
                    }
                }

            }
            timer += Time.deltaTime;

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

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

        public override void EnterState(EnemyAI enemy)
        {
            timer = 0;
            delay = 1;
        }

        public override void Execute(EnemyAI enemy)
        {
            if (timer >= delay)
            {
                enemy.gameObject.Transform.Rotation += new Vector3(0,1,0) * Time.deltaTime;
                Debug.WriteLine(enemy.gameObject.Transform.forward);
                timer = 0;
            }

            if (enemy.health <= 0)
            {
                enemy.ChangeState(new DeathState());
            }

            if (enemy.enemySight.isPlayerSeen)
            {
                enemy.ChangeState(new ChaseState());
            }
        }

        public override void Exit(EnemyAI enemy)
        {
            
        }
    }
}

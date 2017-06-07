using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;

namespace Insight.Scripts.EnemyStates
{
    class FightState : EnemyAIState
    {
        private float timer;
        private float wait;

        public override void EnterState(EnemyAI enemy)
        {
            timer = 0;
            wait = 1;
            Debug.WriteLine("Enter Fight State");
        }

        public override void Execute(EnemyAI enemy)
        {
            if(timer >= wait)
            {
                if (enemy.nearestEnemyPosition.GetComponent<EnemyAI>().health > 0)
                {
                    enemy.nearestEnemyPosition.GetComponent<EnemyAI>().Hit(10);
                }
                
                timer = 0;
            }
            timer += Time.deltaTime;
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Enter Fight State");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Scripts.EnemyStates
{
    class CheckState : EnemyAIState
    {
        public override void EnterState(EnemyAI enemy)
        {
            Debug.WriteLine("Enter Check State");
        }

        public override void Execute(EnemyAI enemy)
        {

            if (enemy.enemySight.isPlayerSeen)
            {
                enemy.ChangeState(new ChaseState());
            }

            if (!enemy.enemySight.isPlayerHeard)
            {
                enemy.ChangeState(enemy.defaultState);
            }
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit Check State");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Scripts.EnemyStates
{
    class DeathState : EnemyAIState
    {
        public override void EnterState(EnemyAI enemy)
        {
            enemy.detect = false;
        }

        public override void Execute(EnemyAI enemy)
        {
            Debug.WriteLine("I'm dead!");
        }

        public override void Exit(EnemyAI enemy)
        {
            
        }
    }
}

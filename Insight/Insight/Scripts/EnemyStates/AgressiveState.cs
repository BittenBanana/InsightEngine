using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Scripts.EnemyStates
{
    class AgressiveState : EnemyAIState
    {
        public override void EnterState(EnemyAI enemy)
        {
            Debug.WriteLine("Enter Agressive State");
        }

        public override void Execute(EnemyAI enemy)
        {
            throw new NotImplementedException();
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Enter Agressive State");
        }
    }
}

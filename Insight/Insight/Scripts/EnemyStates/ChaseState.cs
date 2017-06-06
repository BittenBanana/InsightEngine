using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;

namespace Insight.Scripts.EnemyStates
{
    class ChaseState : EnemyAIState
    {
        public override void EnterState(EnemyAI enemy)
        {
            
        }

        public override void Execute(EnemyAI enemy)
        {
            EnemyWalkingSpots.getInstance().MoveToDestination(enemy.gameObject.Transform.Position,
                enemy.enemySight.lastSeenPosition, 0.1f);
        }

        public override void Exit(EnemyAI enemy)
        {
            throw new NotImplementedException();
        }
    }
}

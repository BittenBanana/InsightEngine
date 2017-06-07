using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine("Enter Chase State");
        }

        public override void Execute(EnemyAI enemy)
        {
            //if(EnemyWalkingSpots.getInstance().DistanceFromDestination(enemy.gameObject.Transform.Position, EnemyWalkingSpots.getInstance().targetDestination) > 0.1f)
            enemy.gameObject.Transform.Position = EnemyWalkingSpots.getInstance().MoveToDestination(enemy.gameObject.Transform.Position,
                enemy.enemySight.lastSeenPosition, 0.1f);
            if (enemy.enemySight.isPlayerHeard && !enemy.enemySight.isPlayerSeen)
            {
                enemy.ChangeState(new CheckState());
            }            
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit Chase State");
        }
    }
}

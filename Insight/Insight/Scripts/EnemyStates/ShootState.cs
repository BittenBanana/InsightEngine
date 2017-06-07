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
    class ShootState : EnemyAIState
    {
        private Physics.RaycastHit hit;
        private Random random;
        private int minRand;
        private int maxRand;

        public override void EnterState(EnemyAI enemy)
        {
            Debug.WriteLine("Enter Shoot State");
            minRand = 1;
            maxRand = 20;
            random = new Random();
        }

        public override void Execute(EnemyAI enemy)
        {
            Vector3 direction = enemy.enemySight.player.Transform.Position - enemy.gameObject.Transform.Position;
            direction += new Vector3((float)random.Next(minRand,maxRand) / 100, (float)random.Next(minRand, maxRand) / 100, (float)random.Next(minRand, maxRand) / 100);
            direction.Normalize();
            if (Physics.Raycast(enemy.gameObject.Transform.Position + direction, direction, out hit))
            {
                if (hit.collider.gameObject.physicLayer == Layer.Player)
                {
                    hit.collider.gameObject.GetComponent<PlayerManager>().GotDamage(random.Next(10, 25));
                }
            }
            enemy.ChangeState(enemy.previousState);
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit Shoot State");
        }
    }
}

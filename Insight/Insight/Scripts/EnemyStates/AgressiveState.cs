using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Insight.Engine.Components;
using Microsoft.Xna.Framework;

namespace Insight.Scripts.EnemyStates
{
    class AgressiveState : EnemyAIState
    {
        private float minDistance = float.PositiveInfinity;
        public override void EnterState(EnemyAI enemy)
        {
            if (enemy.enemySight.detectionLevel >= 0.5f)
            {
                enemy.nearestEnemyPosition = enemy.enemySight.player;
                return;
            }
            Debug.WriteLine("Enter Agressive State");
            foreach (GameObject item in SceneManager.Instance.GetGameObjectsFromCurrentScene())
            {
                if(item.physicLayer != Layer.Enemy) continue;
                if(item == enemy.gameObject) continue;
                if (enemy.nearestEnemyPosition == null)
                {
                    enemy.nearestEnemyPosition = item;
                    minDistance = Vector3.Distance(item.Transform.Position, enemy.gameObject.Transform.Position);
                }
                else
                {
                    float distance = Vector3.Distance(item.Transform.Position, enemy.gameObject.Transform.Position);
                    if (distance < minDistance)
                    {
                        enemy.nearestEnemyPosition = item;
                    }
                }
            }
            
            enemy.detect = false;
        }

        public override void Execute(EnemyAI enemy)
        {
            if (EnemyWalkingSpots.getInstance().DistanceFromDestination(enemy.gameObject.Transform.Position,
                    enemy.nearestEnemyPosition.Transform.Position) > 0.1f)
            {
                if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 1)
                    enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(1);
                EnemyWalkingSpots.getInstance().MoveGameObjectToDestination(enemy.gameObject,
                    enemy.nearestEnemyPosition.Transform.Position, 0.05f, 0.1f);
            }
            else
            {
                if (enemy.nearestEnemyPosition.physicLayer == Layer.Enemy)
                {
                    enemy.nearestEnemyPosition.GetComponent<EnemyAI>().nearestEnemyPosition = enemy.gameObject;
                    enemy.nearestEnemyPosition.GetComponent<EnemyAI>().ChangeState(new FightState());
                }
                enemy.ChangeState(new FightState());
            }
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Enter Agressive State");
        }
    }
}

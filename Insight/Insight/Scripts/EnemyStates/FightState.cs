using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Insight.Engine.Components;

namespace Insight.Scripts.EnemyStates
{
    class FightState : EnemyAIState
    {
        private float timer, timerAfter;
        private float wait, waitAfter;

        public override void EnterState(EnemyAI enemy)
        {
            timer = 0;
            timerAfter = 0;
            wait = 1;
            waitAfter = 3;
            Debug.WriteLine("Enter Fight State");
            enemy.detect = false;
            if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 4)
                enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(4,true); // TODO Fight Animation
        }

        public override void Execute(EnemyAI enemy)
        {
            if (enemy.nearestEnemyPosition != null)
            {
                if (timer >= wait)
                {
                    if (enemy.nearestEnemyPosition.physicLayer == Layer.Enemy)
                    {
                        if (enemy.nearestEnemyPosition.GetComponent<EnemyAI>().health > 0)
                        {
                            enemy.nearestEnemyPosition.GetComponent<EnemyAI>().Hit(10);
                        }

                    }
                    else
                    {
                        enemy.nearestEnemyPosition.GetComponent<PlayerManager>().GotDamage(20);
                    }

                    timer = 0;
                }


                if (enemy.nearestEnemyPosition.physicLayer == Layer.Enemy)
                {
                    if (enemy.nearestEnemyPosition.GetComponent<EnemyAI>().health <= 0)
                    {
                        if (timerAfter >= waitAfter)
                        {
                            enemy.detect = true;
                            enemy.ChangeState(new StandAndLookState());
                            timerAfter = 0;
                        }
                        timerAfter += Time.deltaTime;
                    }
                }

                if (EnemyWalkingSpots.getInstance().DistanceFromDestination(enemy.gameObject.Transform.Position,
                        enemy.nearestEnemyPosition.Transform.Position) >= 0.5f)
                {
                    enemy.ChangeState(enemy.previousState);
                }

                timer += Time.deltaTime;
            }
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit Fight State");
        }
    }
}

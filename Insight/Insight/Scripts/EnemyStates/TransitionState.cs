using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Insight.Engine.Components;

namespace Insight.Scripts.EnemyStates
{
    class TransitionState : EnemyAIState
    {
        private float timer, delay;

        public override void EnterState(EnemyAI enemy)
        {
            timer = 0;
            delay = 2;
            if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 3) // TODO change to transition animation
                enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(3,false);
        }

        public override void Execute(EnemyAI enemy)
        {
            if (timer >= delay)
            {
                if (enemy.nextState != null)
                {
                    enemy.ChangeState(enemy.nextState);
                }
                else
                {
                    enemy.ChangeState(enemy.defaultState);
                }
            }
            timer += Time.deltaTime;
        }

        public override void Exit(EnemyAI enemy)
        {
            enemy.nextState = null;
        }
    }
}

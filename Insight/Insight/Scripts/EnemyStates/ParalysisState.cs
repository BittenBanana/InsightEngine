using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine.Components;

namespace Insight.Scripts.EnemyStates
{
    class ParalysisState : EnemyAIState
    {
        public override void EnterState(EnemyAI enemy)
        {
            Debug.WriteLine("Enter ParalysisState");
            enemy.detect = false;
            if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 1)
                enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(2); //TODO Paralysis Animation
        }

        public override void Execute(EnemyAI enemy)
        {

        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit ParalysisState");
        }
    }
}

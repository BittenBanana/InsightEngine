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
    class ParalysisState : EnemyAIState
    {
        private float timer;

        public override void EnterState(EnemyAI enemy)
        {
            timer = 0;
            Debug.WriteLine("Enter ParalysisState");
            enemy.detect = false;
            if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 5)
                enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(5,false); //TODO Paralysis Animation
        }

        public override void Execute(EnemyAI enemy)
        {
            if (timer >= enemy.gameObject.GetComponent<AnimationRender>().GetCurrentClip().Duration.Seconds)
            {
                enemy.gameObject.GetComponent<Collider>().IsTrigger = true;
            }
            timer += Time.deltaTime;
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit ParalysisState");
        }
    }
}

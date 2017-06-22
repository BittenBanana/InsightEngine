using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine.Components;
using Microsoft.Xna.Framework;

namespace Insight.Scripts.EnemyStates
{
    class DeathState : EnemyAIState
    {
        public override void EnterState(EnemyAI enemy)
        {
            enemy.detect = false;
            if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 1)
                enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(2); //TODO Death Animation
        }

        public override void Execute(EnemyAI enemy)
        {
            //Debug.WriteLine("I'm dead!");
        }

        public override void Exit(EnemyAI enemy)
        {
            
        }
    }
}

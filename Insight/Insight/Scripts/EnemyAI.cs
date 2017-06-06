using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework.Media;

namespace Insight.Scripts
{
    class EnemyAI : BaseScript
    {
        public enum AiState
        {
            None,
            WalkingToFirstPoint,
            WalkingToSecondPoint,
            FollowingPlayer,
        }

        private EnemyAIState currentState;

        public EnemyAI(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Update()
        {
            if (currentState != null)
            {
                currentState.Execute(this);
            }
            base.Update();
        }

        public void ChangeState(EnemyAIState newState)
        {
            currentState.Exit(this);
            currentState = newState;
            currentState.EnterState(this);
        }
    }
}

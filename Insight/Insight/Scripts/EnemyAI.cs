using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public int health { get; private set; }

        public EnemySight enemySight { get; set; }

        private EnemyAIState currentState;
        public EnemyAIState defaultState { get; private set; }

        public EnemyAI(GameObject gameObject) : base(gameObject)
        {
            health = 100;
        }

        public override void Update()
        {
            currentState?.Execute(this);
            //Debug.WriteLine(currentState);
            base.Update();
        }

        public void ChangeState(EnemyAIState newState)
        {
            currentState.Exit(this);
            currentState = newState;
            currentState.EnterState(this);
        }

        public void SetFirstState(EnemyAIState state)
        {
            currentState = state;
            defaultState = state;
        }

        public void Hit(int dmg)
        {
            health -= dmg;
        }
    }
}

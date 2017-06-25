using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Insight.Scripts.EnemyStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Insight.Scripts
{
    class EnemyAI : BaseScript
    {
        private bool enabled;
        public enum AiState
        {
            None,
            WalkingToFirstPoint,
            WalkingToSecondPoint,
            FollowingPlayer,
        }

        public int health { get; private set; }

        public EnemySight enemySight { get; set; }
        public Vector3? markerPosition { get; set; }

        public bool detect { get; set; }

        public EnemyAIState currentState { get; private set; }
        public EnemyAIState previousState { get; set; }
        public EnemyAIState defaultState { get; private set; }
        public EnemyAIState nextState { get; set; }

        /// <summary>
        /// Must be set for Patrol State
        /// </summary>
        public List<Vector3> patrolPositions { get; private set; }

        /// <summary>
        /// May be set for Stand State default is gameObject.Transform.Position
        /// </summary>
        public Vector3 standPosition { get; set; }
        public Vector3 defaultRotation { get; private set; }

        public GameObject nearestEnemyPosition { get; set; }

        public EnemyAI(GameObject gameObject) : base(gameObject)
        {
            enabled = true;
            nearestEnemyPosition = null;
            //patrolPositions = new List<Vector3>();
            standPosition = gameObject.Transform.Position;
            defaultRotation = gameObject.Transform.Rotation;
            health = 100;
            detect = true;
        }

        public override void Update()
        {
            if (enabled)
            {
                if (health <= 0 && !(currentState is DeathState))
                    ChangeState(new DeathState());
                currentState?.Execute(this);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F3))
            {
                enabled = !enabled;
            }
            //Debug.WriteLine(currentState);
            base.Update();
        }

        public void ChangeState(EnemyAIState newState)
        {
            previousState = currentState;
            currentState.Exit(this);
            currentState = newState;
            currentState.EnterState(this);
        }

        /// <summary>
        /// this method change state to transitionState and the nextState after it
        /// </summary>
        /// <param name="transitionState">set TransitionState only otherwise nextState won't be executed</param>
        /// <param name="nextState">this state will be set after transitionState</param>
        public void ChangeState(EnemyAIState transitionState, EnemyAIState nextState)
        {
            previousState = currentState;
            this.nextState = nextState;
            currentState.Exit(this);
            currentState = transitionState;
            currentState.EnterState(this);
        }

        public void SetPatrolPositions(List<Vector3> positions)
        {
            patrolPositions = positions;
        }

        public void SetFirstState(EnemyAIState state)
        {
            currentState = state;
            defaultState = state;
            currentState.EnterState(this);
        }

        public void Hit(int dmg)
        {
            if (health > 0)
                health -= dmg;
        }

        public void HeathBoost(int boost)
        {
            if (health > 0)
                health += boost;
        }
    }
}

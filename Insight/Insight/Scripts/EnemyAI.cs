using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Insight.Scripts.EnemyStates;
using Microsoft.Xna.Framework;
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
        public Vector3? markerPosition { get; set; }

        private EnemyAIState currentState;
        public EnemyAIState previousState { get; set; }
        public EnemyAIState defaultState { get; private set; }

        /// <summary>
        /// Must be set for Patrol State
        /// </summary>
        public List<Vector3> patrolPositions { get; private set; }

        /// <summary>
        /// May be set for Stand State default is gameObject.Transform.Position
        /// </summary>
        public Vector3 standPosition { get; set; }
        public Vector3 defaultRotation { get; private set; }

        public EnemyAI(GameObject gameObject) : base(gameObject)
        {
            patrolPositions = new List<Vector3>();
            standPosition = gameObject.Transform.Position;
            defaultRotation = gameObject.Transform.Rotation;
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
            //previousState = currentState;
            currentState.Exit(this);
            currentState = newState;
            currentState.EnterState(this);
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
            else
                ChangeState(new DeathState());
        }
    }
}

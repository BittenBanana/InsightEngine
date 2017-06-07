using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace Insight.Scripts
{
    class BasicAI : BaseScript
    {
        enum AiState
        {
            None,
            WalkingToFirstPoint,
            WalkingToSecondPoint,
            FollowingPlayer,
        }
        Vector3 destinationPosition;
        Vector3 currentNodePos;
        private AiState state;
        private List<int> visitedPath = new List<int>();

        Vector3 point1, point2;
        public BasicAI(GameObject gameObject) : base(gameObject)
        {
            //point1 = new Vector3(17.5f, 0, 13.5f);
            point1 = new Vector3(17.5f, 0, 13.5f);
            point2 = gameObject.Transform.Position;
            state = AiState.None;
            destinationPosition = this.gameObject.Transform.Position;
            visitedPath.Add(9);
        }

        public override void Update()
        {
            base.Update();
            //if(state == AiState.WalkingToFirstPoint)
            //{
            //    gameObject.Transform.Position = VectorHelper.MoveTowards(gameObject.Transform.Position, point1, 0.05f);

            //    if (Vector3.Distance(gameObject.Transform.Position, point1) < 0.1f)
            //        state = AiState.WalkingToSecondPoint;

            //    Vector3 direction = point1 - gameObject.Transform.Position;
            //    gameObject.Transform.Rotation.Y = (float)Math.Atan2(direction.Y, direction.X) + 0.45f;
            //}


            //if (state == AiState.WalkingToSecondPoint)
            //{
            //    gameObject.Transform.Position = VectorHelper.MoveTowards(gameObject.Transform.Position, point2, 0.05f);

            //    if (Vector3.Distance(gameObject.Transform.Position, point2) < 0.1f)
            //        state = AiState.WalkingToFirstPoint;

            //    Vector3 direction = point2 - gameObject.Transform.Position;
            //    gameObject.Transform.Rotation.Y = (float)Math.Atan2(direction.Y, direction.X) + 0.45f;
            //}
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Tab))
            {
                state = AiState.FollowingPlayer;
                destinationPosition = EnemyWalkingSpots.getInstance().findNearestNode(SceneManager.Instance.currentScene.player.Transform.Position).rootPoint;
                currentNodePos = this.gameObject.Transform.Position;
            }

            if (state == AiState.FollowingPlayer)
            {
                //Debug.WriteLine(EnemyWalkingSpots.getInstance().DistanceFromDestination(this.gameObject.Transform.Position, destinationPosition));

                EnemyWalkingSpots.getInstance().MoveGameObjectToDestination(gameObject, destinationPosition, 0.05f, 2.0f);

            }
        }
    }
}

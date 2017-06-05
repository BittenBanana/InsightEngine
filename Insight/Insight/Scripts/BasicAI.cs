using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;

namespace Insight.Scripts
{
    class BasicAI : BaseScript
    {
        enum AiState
        {
            WalkingToFirstPoint,
            WalkingToSecondPoint
        }

        private AiState state;

        Vector3 point1, point2;
        public BasicAI(GameObject gameObject) : base(gameObject)
        {
            point1 = new Vector3(18, 0, 5);
            point2 = gameObject.Transform.Position;
            state = AiState.WalkingToFirstPoint;
        }

        public override void Update()
        {
            base.Update();
            if(state == AiState.WalkingToFirstPoint)
            {
                gameObject.Transform.Position = VectorHelper.MoveTowards(gameObject.Transform.Position, point1, 0.05f);

                if (Vector3.Distance(gameObject.Transform.Position, point1) < 0.1f)
                    state = AiState.WalkingToSecondPoint;

                Vector3 direction = point1 - gameObject.Transform.Position;
                gameObject.Transform.Rotation.Y = (float)Math.Atan2(direction.Y, direction.X) + 0.45f;
            }


            if (state == AiState.WalkingToSecondPoint)
            {
                gameObject.Transform.Position = VectorHelper.MoveTowards(gameObject.Transform.Position, point2, 0.05f);

                if (Vector3.Distance(gameObject.Transform.Position, point2) < 0.1f)
                    state = AiState.WalkingToFirstPoint;

                Vector3 direction = point2 - gameObject.Transform.Position;
                gameObject.Transform.Rotation.Y = (float)Math.Atan2(direction.Y, direction.X) + 0.45f;
            }

            

        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine
{
    class VectorHelper
    {
        static public Vector3 MoveTowards(Vector3 currentPosition, Vector3 targetPosition, float maxDistanceDelta)
        {
            Vector3 a = targetPosition - currentPosition;
            float magnitude = Vector3.Distance(currentPosition, targetPosition);
            if (magnitude <= maxDistanceDelta || magnitude == 0f)
            {
                return targetPosition;
            }
            return currentPosition + a / magnitude * maxDistanceDelta;
        }
    }
}

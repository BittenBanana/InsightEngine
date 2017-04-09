using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine
{
    static class Physics
    {
        private static Vector3 gravity = new Vector3(0, -9.81f, 0);
        public static Vector3 Gravity
        {
            get { return gravity; }
            private set { gravity = value; }
        }
    }
}

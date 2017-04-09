using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine
{
    public class CollisionEventArgs : EventArgs
    {
        public Vector3 LastPosition { get; set; }
    }
}

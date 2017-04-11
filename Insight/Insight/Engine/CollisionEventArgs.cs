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
        public GameObject GameObject { get; set; }
    }
}

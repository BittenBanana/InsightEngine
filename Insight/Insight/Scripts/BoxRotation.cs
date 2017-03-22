using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;

namespace Insight.Scripts
{
    class BoxRotation : BaseScript
    {
        public BoxRotation(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Update()
        {
            gameObject.Transform.Rotation.Y += .05f;
            base.Update();
        }
    }
}

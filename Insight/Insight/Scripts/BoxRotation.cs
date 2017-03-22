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
        float val = 0;
        public BoxRotation(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Update()
        {
            val += .05f;
            gameObject.Transform.Rotate(Vector3.UnitY, val);
            base.Update();
        }
    }
}

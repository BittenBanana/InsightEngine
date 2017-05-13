using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Insight.Engine
{
    public class Material
    {
        protected Effect effect;

        public Material(Effect effect)
        {
            this.effect = effect;
        }

        public Effect GetEffect()
        {
            return effect;
        }

        public virtual void SetParameters()
        {
        }
    }
}

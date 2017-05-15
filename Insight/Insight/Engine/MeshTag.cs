using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Insight.Engine
{
    public class MeshTag
    {
        public Vector3 Color;
        public Texture2D Texture;
        public float SpecularPower;
        public Dictionary<string,EffectParameter> parameters;
        public Effect CachedEffect = null;

        public MeshTag(Effect effect)
        {
            parameters = new Dictionary<string, EffectParameter>();

            foreach (var parameter in effect.Parameters)
            {
                parameters.Add(parameter.Name, parameter);
            }
        }
    }
}

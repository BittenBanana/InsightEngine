using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Insight.Materials
{
    class DefaultMaterial : Material
    {
        public Vector3 AmbientColor { get; set; }
        public Vector3 LightDirection { get; set; }
        public Vector3 LightColor { get; set; }
        public Vector3 SpecularColor { get; set; }

        public float AmbientIntesity { get; set; }
        public float DiffuseIntensity { get; set; }
        public float SpecularIntensity { get; set; }

        public DefaultMaterial(Effect effect) : base(effect)
        {
            LightDirection = Vector3.Normalize(new Vector3(-0.5f, -0.5f, 0.0f));
            AmbientColor = new Vector3(1,1,1);
            LightColor = new Vector3(1,1,1);
            SpecularColor = new Vector3(1,1,1);

            AmbientIntesity = 0.2f;
            DiffuseIntensity = 0.4f;
            SpecularIntensity = 0.3f;
        }

        public override void SetParameters()
        {
            effect.Parameters["AmbientColor"]?.SetValue(AmbientColor);
            effect.Parameters["AmbientIntensity"]?.SetValue(AmbientIntesity);
            effect.Parameters["LightDirection"]?.SetValue(LightDirection);
            effect.Parameters["DiffuseColor"]?.SetValue(LightColor);
            effect.Parameters["DiffuseIntensity"]?.SetValue(DiffuseIntensity);
            effect.Parameters["SpecularColor"]?.SetValue(SpecularColor);
            effect.Parameters["SpecularIntensity"]?.SetValue(SpecularIntensity);
        }
    }
}

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
    class PointLightMaterial : Material
    {
        public Vector3 AmbientColor { get; set; }
        public Vector3 LightPosition { get; set; }
        public Vector3 LightColor { get; set; }
        public Vector3 SpecularColor { get; set; }

        public float AmbientIntesity { get; set; }
        public float DiffuseIntensity { get; set; }
        public float SpecularIntensity { get; set; }

        public float LightAttenuation { get; set; }
        public float LightFalloff { get; set; }

        public PointLightMaterial(Effect effect) : base(effect)
        {
            AmbientColor = new Vector3(.15f, .15f, .15f);
            LightPosition = new Vector3(0, 0, 0);
            LightColor = new Vector3(.85f, .85f, .85f);
            SpecularColor = new Vector3(.85f, .85f, .85f);

            LightAttenuation = 5000;
            LightFalloff = 2;
        }

        public override void SetParameters()
        {
            effect.Parameters["AmbientColor"]?.SetValue(AmbientColor);
            effect.Parameters["AmbientIntensity"]?.SetValue(AmbientIntesity);
            effect.Parameters["LightPosition"]?.SetValue(LightPosition);
            effect.Parameters["DiffuseColor"]?.SetValue(LightColor);
            effect.Parameters["DiffuseIntensity"]?.SetValue(DiffuseIntensity);
            effect.Parameters["SpecularColor"]?.SetValue(SpecularColor);
            effect.Parameters["SpecularIntensity"]?.SetValue(SpecularIntensity);
            effect.Parameters["LightAttenuation"]?.SetValue(LightAttenuation);
            effect.Parameters["LightFalloff"]?.SetValue(LightFalloff);
        }
    }
}

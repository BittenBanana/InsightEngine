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
    class SpotLightMaterial : Material
    {
        public Vector3 AmbientColor { get; set; }
        public Vector3 LightPosition { get; set; }
        public Vector3 LightDirection { get; set; }
        public Vector3 LightColor { get; set; }
        public Vector3 SpecularColor { get; set; }

        public float AmbientIntesity { get; set; }
        public float DiffuseIntensity { get; set; }
        public float SpecularIntensity { get; set; }

        public float ConeAngle { get; set; }
        public float LightFalloff { get; set; }

        public SpotLightMaterial(Effect effect) : base(effect)
        {
            AmbientColor = new Vector3(.15f, .15f, .15f);
            LightPosition = new Vector3(0, 3000, 0);
            LightColor = new Vector3(.85f, .85f, .85f);
            SpecularColor = new Vector3(.85f, .85f, .85f);

            ConeAngle = 3;

            LightDirection = new Vector3(0, -1, 0);

            LightFalloff = 20;
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
            effect.Parameters["LightFalloff"]?.SetValue(LightFalloff);
            effect.Parameters["ConeAngle"]?.SetValue(ConeAngle);
            effect.Parameters["LightDirection"]?.SetValue(LightDirection);
        }
    }
}

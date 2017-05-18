using Insight.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Materials
{
    class TransparencyMaterial : Material
    {
        public Vector3 DiffuseLightDirection { get; set; }
        public Vector3 DiffuseColor { get; set; }
        public float DiffuseIntensity { get; set; }

        public float Shininess { get; set; }
        public Vector3 SpecularColor { get; set; }
        public float SpecularIntensity { get; set; }
        public Vector3 ViewVector { get; set; }

        public float Transparency { get; set; }

        public TransparencyMaterial(Effect effect) : base(effect)
        {
            DiffuseLightDirection = new Vector3(1, 0, 0);
            DiffuseColor = new Vector3(1, 1, 1);
            DiffuseIntensity = 1.0f;

            Shininess = 200;
            SpecularColor = new Vector3(1, 1, 1);
            SpecularIntensity = 1;
            ViewVector = new Vector3(1, 0, 0);

            Transparency = 0.5f;
        }

        public override void SetParameters()
        {
            effect.Parameters["DiffuseLightDirection"]?.SetValue(DiffuseLightDirection);
            effect.Parameters["DiffuseColor"]?.SetValue(DiffuseColor);
            effect.Parameters["DiffuseIntensity"]?.SetValue(DiffuseIntensity);
            effect.Parameters["Shininess"]?.SetValue(Shininess);
            effect.Parameters["SpecularColor"]?.SetValue(SpecularColor);
            effect.Parameters["SpecularIntensity"]?.SetValue(SpecularIntensity);
            effect.Parameters["ViewVector"]?.SetValue(ViewVector);
            effect.Parameters["Transparency"]?.SetValue(Transparency);
        }

        public override object Clone()
        {
            TransparencyMaterial result = new TransparencyMaterial(effect);
            result.DiffuseLightDirection = DiffuseLightDirection;
            result.DiffuseColor = DiffuseColor;
            result.DiffuseIntensity = DiffuseIntensity;
            result.Shininess = Shininess;
            result.SpecularColor = SpecularColor;
            result.SpecularIntensity = SpecularIntensity;
            result.ViewVector = ViewVector;
            result.Transparency = Transparency;
            return result;
        }
    }
}

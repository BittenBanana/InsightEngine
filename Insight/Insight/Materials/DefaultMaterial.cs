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

        public Texture2D BasicTexture { get; set; }
        public Texture2D LighTexture { get; set; }
        public bool TextureEnabled { get; set; }

        public DefaultMaterial(Effect effect) : base(effect)
        {
            LightDirection = Vector3.Normalize(new Vector3(-1f, -1f, 0.0f));
            AmbientColor = new Vector3(1,1,1);
            LightColor = new Vector3(1,1,1);
            SpecularColor = new Vector3(1,1,1);

            AmbientIntesity = 0.6f;
            DiffuseIntensity = 0.8f;
            SpecularIntensity = 0.8f;

            BasicTexture = null;
            TextureEnabled = false;
            LighTexture = null;
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
            if(BasicTexture != null)
                effect.Parameters["BasicTexture"]?.SetValue(BasicTexture);
            //if(LighTexture != null)
            //    effect.Parameters["LighTexture"]?.SetValue(LighTexture);
            effect.Parameters["TextureEnabled"]?.SetValue(TextureEnabled);
        }

        public override object Clone()
        {
            DefaultMaterial result = new DefaultMaterial(effect);
            result.AmbientIntesity = AmbientIntesity;
            result.BasicTexture = BasicTexture;
            result.DiffuseIntensity = DiffuseIntensity;
            result.LightColor = LightColor;
            result.LightDirection = LightDirection;
            result.SpecularColor = SpecularColor;
            result.SpecularIntensity = SpecularIntensity;
            result.TextureEnabled = TextureEnabled;
            result.AmbientColor = AmbientColor;
            result.LighTexture = LighTexture;
            return result;
        }
    }
}

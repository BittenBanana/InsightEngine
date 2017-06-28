using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine.Components
{
    public class Renderer : Component
    {
        protected Model model;
        protected Matrix[] boneTransformations;
        protected float scale;

        protected Effect effect;
        public Material Material { get; set; }
        protected Texture2D texture;
        protected Texture2D normal;
        protected Texture2D ao;
        protected Texture2D metalness;

        protected Matrix World;

        public bool IsVisible { get; set; }

        public Renderer(GameObject gameObject) : base(gameObject)
        {
        }

        public virtual void Load(ContentManager c)
        {

        }

        public void SetModelMaterial(Material material, bool CopyEffect)
        {
            this.Material = material;
            effect = material.GetEffect();
        }

        public void LoadTexture(ContentManager c, string path)
        {
            texture = c.Load<Texture2D>(path);
        }

        public void LoadNormalMap(ContentManager c, string path)
        {
            normal = c.Load<Texture2D>(path);
        }

        public void LoadAmbientOcclusionMap(ContentManager c, string path)
        {
            ao = c.Load<Texture2D>(path);
        }

        public void LoadMetalnessMap(ContentManager c, string path)
        {
            metalness = c.Load<Texture2D>(path);
        }

        public virtual Model getModel()
        {
            return model;
        }

        public virtual float GetScale()
        {
            return scale;
        }

        public Matrix GetMatrix()
        {
            return Matrix.CreateScale(scale)
                   * Matrix.CreateFromAxisAngle(Vector3.UnitX, gameObject.Transform.Rotation.X)
                   * Matrix.CreateFromAxisAngle(Vector3.UnitY, gameObject.Transform.Rotation.Y)
                   * Matrix.CreateFromAxisAngle(Vector3.UnitZ, gameObject.Transform.Rotation.Z)
                   * Matrix.CreateTranslation(gameObject.Transform.Position);
        }
    }
}

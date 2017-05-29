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

        public Renderer(GameObject gameObject) : base(gameObject)
        {
        }

        public virtual void Load(ContentManager c)
        {

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
                        * Matrix.CreateFromQuaternion(gameObject.Transform.quaterion)
                        * Matrix.CreateScale(scale)
                        * Matrix.CreateTranslation(gameObject.Transform.Position)
                        * Matrix.CreateTranslation(gameObject.Transform.origin);
        }
    }
}

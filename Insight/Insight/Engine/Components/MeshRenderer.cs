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
    public class MeshRenderer : Component
    {
        Model model;
        Matrix[] boneTransformations;

        public MeshRenderer(GameObject gameObject) : base (gameObject)
        {
        }
        public void Load(ContentManager c)
        {
            model = c.Load<Model>("GameObject/boxMat");
        }

        public void Load(ContentManager c, string path)
        {
            model = c.Load<Model>(path);
        }

        public Model getModel()
        {
            return model;
        }

        public void Draw(Camera camera)
        {
            boneTransformations = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(boneTransformations);

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = boneTransformations[mesh.ParentBone.Index] * Matrix.CreateScale(2f) * Matrix.CreateRotationX(gameObject.Transform.Rotation.X) * Matrix.CreateRotationY(gameObject.Transform.Rotation.Y) * Matrix.CreateRotationZ(gameObject.Transform.Rotation.Z) * Matrix.CreateTranslation(gameObject.Transform.Position);
                    effect.View = camera.view;
                    effect.Projection = camera.projection;
                    effect.EnableDefaultLighting();
                }
                mesh.Draw();
            }
        }
        
    }
}

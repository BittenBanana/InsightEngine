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
        float scale;

        public MeshRenderer(GameObject gameObject) : base (gameObject)
        {
            scale = 0.1f;
        }
        public void Load(ContentManager c)
        {
            model = c.Load<Model>("viking");
        }

        public void Load(ContentManager c, string path, float scale)
        {
            model = c.Load<Model>(path);
            this.scale = scale;
        }

        public Model getModel()
        {
            return model;
        }

        public float GetScale()
        {
            return scale;
        }

        public void Draw(Camera camera)
        {
            boneTransformations = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(boneTransformations);

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    //effect.World = boneTransformations[mesh.ParentBone.Index] 
                    //    * Matrix.CreateScale(scale) 
                    //    * Matrix.CreateRotationX(gameObject.Transform.Rotation.X) 
                    //    * Matrix.CreateRotationY(gameObject.Transform.Rotation.Y) 
                    //    * Matrix.CreateRotationZ(gameObject.Transform.Rotation.Z) 
                    //    * Matrix.CreateTranslation(gameObject.Transform.Position);
                    effect.World = boneTransformations[mesh.ParentBone.Index]
                        * Matrix.CreateScale(scale)
                        * Matrix.CreateFromQuaternion(gameObject.Transform.quaterion)
                        * Matrix.CreateTranslation(gameObject.Transform.Position)
                        * Matrix.CreateTranslation(gameObject.Transform.origin);

                    effect.View = camera.view;
                    effect.Projection = camera.projection;
                    effect.EnableDefaultLighting();
                }
                mesh.Draw();
            }
        }

        public Matrix GetMatrix()
        {
            return Matrix.CreateScale(scale)
                        * Matrix.CreateFromQuaternion(gameObject.Transform.quaterion)
                        * Matrix.CreateTranslation(gameObject.Transform.Position)
                        * Matrix.CreateTranslation(gameObject.Transform.origin);
        }

    }
}

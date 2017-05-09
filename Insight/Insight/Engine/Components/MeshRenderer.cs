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
        Texture2D texture;
        Matrix[] boneTransformations;
        float scale;
        public bool IsVisible {get; set;}

        public MeshRenderer(GameObject gameObject) : base (gameObject)
        {
            scale = 0.1f;
            IsVisible = true;
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

        public void LoadTexture(ContentManager c, string path)
        {
            texture = c.Load<Texture2D>(path);
        }

        public Model getModel()
        {
            return model;
        }

        public float GetScale()
        {
            return scale;
        }

        public override void Draw(Camera cam)
        {
            if(IsVisible)
            {
                boneTransformations = new Matrix[model.Bones.Count];
                model.CopyAbsoluteBoneTransformsTo(boneTransformations);

                foreach (ModelMesh mesh in model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        //effect.Texture = texture;
                        //if (texture != null)
                        //    effect.TextureEnabled = true;
                        //effect.World = boneTransformations[mesh.ParentBone.Index] 
                        //    * Matrix.CreateScale(scale) 
                        //    * Matrix.CreateRotationX(gameObject.Transform.Rotation.X) 
                        //    * Matrix.CreateRotationY(gameObject.Transform.Rotation.Y) 
                        //    * Matrix.CreateRotationZ(gameObject.Transform.Rotation.Z) 
                        //    * Matrix.CreateTranslation(gameObject.Transform.Position);
                        //if(gameObject.isCube == true)
                        //{
                        //    effect.TextureEnabled = true;
                        //}
                        effect.World = boneTransformations[mesh.ParentBone.Index]
                            * Matrix.CreateScale(scale)
                            * Matrix.CreateFromQuaternion(gameObject.Transform.quaterion)
                            * Matrix.CreateTranslation(gameObject.Transform.Position)
                            * Matrix.CreateTranslation(gameObject.Transform.origin);

                        effect.View = cam.view;
                        effect.Projection = cam.projection;

                        effect.EnableDefaultLighting();
                    }
                    mesh.Draw();
                }
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

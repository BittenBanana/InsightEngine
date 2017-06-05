using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Scenes;

namespace Insight.Engine.Components
{
    public class MeshRenderer : Renderer
    {
        //Model model;

        //Matrix[] boneTransformations;


        //float scale;
        public bool IsVisible { get; set; }

        public MeshRenderer(GameObject gameObject) : base(gameObject)
        {
            scale = 1f;
            IsVisible = true;
        }
        public override void Load(ContentManager c)
        {
            model = c.Load<Model>("Models/Konrads/Character/badass1_8m");
            generateTags();
            scale = 1f;
            effect = Material.GetEffect();
        }

        public void Load(ContentManager c, string path, float scale)
        {
            model = c.Load<Model>(path);
            generateTags();
            effect = Material.GetEffect();
            this.scale = scale;
        }



        //public Model getModel()
        //{
        //    return model;
        //}

        //public float GetScale()
        //{
        //    return scale;
        //}

        // Store references to all of the model's current effects
        public void CacheEffects()
        {

            foreach (ModelMesh mesh in model.Meshes)
                foreach (ModelMeshPart part in mesh.MeshParts)
                    ((MeshTag)part.Tag).CachedEffect = part.Effect;
        }

        public void RestoreEffects()
        {
            foreach (ModelMesh mesh in model.Meshes)
                foreach (ModelMeshPart part in mesh.MeshParts)
                    if (((MeshTag)part.Tag).CachedEffect != null)
                        part.Effect = ((MeshTag)part.Tag).CachedEffect;
        }



        private void generateTags()
        {
            foreach (ModelMesh mesh in model.Meshes)
                foreach (ModelMeshPart part in mesh.MeshParts)
                    if (part.Effect is Effect)
                    {
                        Effect effect = (Effect)part.Effect;
                        MeshTag tag = new MeshTag(effect);
                        part.Tag = tag;
                    }
        }

        public override void Draw(Camera cam)
        {
            if (IsVisible)
            {
                boneTransformations = new Matrix[model.Bones.Count];
                model.CopyAbsoluteBoneTransformsTo(boneTransformations);

                foreach (ModelMesh mesh in model.Meshes)
                {
                    foreach (ModelMeshPart p in mesh.MeshParts)
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
                        p.Effect = effect;
                        Material.SetParameters();
                        if (texture != null)
                        {
                            effect.Parameters["BasicTexture"]?.SetValue(texture);
                            effect.Parameters["TextureEnabled"]?.SetValue(true);
                        }
                        else
                        {
                            effect.Parameters["TextureEnabled"]?.SetValue(false);
                        }

                        if (normal != null)
                        {
                            effect.Parameters["NormalTexture"]?.SetValue(normal);
                            effect.Parameters["NormalEnabled"]?.SetValue(true);
                        }
                        else
                        {
                            effect.Parameters["NormalEnabled"]?.SetValue(false);
                        }

                        if (ao != null)
                        {
                            effect.Parameters["AOTexture"]?.SetValue(ao);
                            effect.Parameters["AOEnabled"]?.SetValue(true);
                        }
                        else
                        {
                            effect.Parameters["AOEnabled"]?.SetValue(false);
                        }

                        if (metalness != null)
                        {
                            effect.Parameters["MetalnessTexture"]?.SetValue(metalness);
                            effect.Parameters["MetalnessEnabled"]?.SetValue(true);
                        }
                        else
                        {
                            effect.Parameters["MetalnessEnabled"]?.SetValue(false);
                        }

                        World = boneTransformations[mesh.ParentBone.Index]
                                                            * Matrix.CreateScale(scale)
                                                            * Matrix.CreateFromAxisAngle(Vector3.UnitX, gameObject.Transform.Rotation.X)
                                                            * Matrix.CreateFromAxisAngle(Vector3.UnitY, gameObject.Transform.Rotation.Y)
                                                            * Matrix.CreateFromAxisAngle(Vector3.UnitZ, gameObject.Transform.Rotation.Z)
                                                            * Matrix.CreateTranslation(gameObject.Transform.Position);
                        effect.Parameters["World"]?.SetValue(World);
                        effect.Parameters["View"]?.SetValue(cam.view);
                        effect.Parameters["Projection"]?.SetValue(cam.projection);
                        effect.Parameters["CamPosition"]?.SetValue(cam.Position);
                        effect.Parameters["WorldInverseTranspose"]?.SetValue(Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * World)));
                        effect.Parameters["ViewVector"]?.SetValue(Vector3.Transform(Vector3.Forward,
                            Matrix.CreateFromAxisAngle(Vector3.UnitX, SceneManager.Instance.currentScene.GetMainCamera().gameObject.Transform.Rotation.X)
                            * Matrix.CreateFromAxisAngle(Vector3.UnitY, SceneManager.Instance.currentScene.GetMainCamera().gameObject.Transform.Rotation.Y)
                            * Matrix.CreateFromAxisAngle(Vector3.UnitZ, SceneManager.Instance.currentScene.GetMainCamera().gameObject.Transform.Rotation.Z)
                            ));

                        effect.CurrentTechnique = effect.Techniques["Basic"];

                        //effect.EnableDefaultLighting();

                    }
                    mesh.Draw();
                }
            }

        }

        //public Matrix GetMatrix()
        //{
        //    return Matrix.CreateScale(scale)
        //                * Matrix.CreateFromQuaternion(gameObject.Transform.quaterion)
        //                * Matrix.CreateTranslation(gameObject.Transform.Position)
        //                * Matrix.CreateTranslation(gameObject.Transform.origin);
        //}

    }
}

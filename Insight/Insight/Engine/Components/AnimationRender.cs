using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SkinnedModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Insight.Engine.Components
{
    public class AnimationRender : Renderer
    {
        //Model model;
        //Matrix[] boneTransformations;

        AnimationPlayer animationPlayer;
        //float scale;
        public AnimationRender(GameObject gameObject) : base(gameObject)
        {

            scale = 1.0f;
        }

        public override void Load(ContentManager c)
        {
            model = c.Load<Model>("Models/Konrads/Character/postacRunGun");
            effect = Material.GetEffect();
            SkinningData skinningData = model.Tag as SkinningData;

            if (skinningData == null)
                throw new InvalidOperationException
                    ("This model does not contain a SkinningData tag.");

            animationPlayer = new AnimationPlayer(skinningData);

            AnimationClip clip = skinningData.AnimationClips["Take 001"];

            animationPlayer.StartClip(clip,0, 31);
        }

        public void Load(ContentManager c, String path, int frames)
        {
            model = c.Load<Model>(path);
            effect = Material.GetEffect();
            SkinningData skinningData = model.Tag as SkinningData;

            if (skinningData == null)
                throw new InvalidOperationException
                    ("This model does not contain a SkinningData tag.");

            animationPlayer = new AnimationPlayer(skinningData);

            AnimationClip clip = skinningData.AnimationClips["Take 001"];

            animationPlayer.StartClip(clip, 0, frames);
        }

        public void SetFrames(int firstFrame, int lastFrame)
        {
            animationPlayer.SetFrames(firstFrame, lastFrame);
        }

        public override void Update()
        {
            animationPlayer.Update(Time.gameTime.ElapsedGameTime, true, Matrix.Identity);

            base.Update();
        }
        public override void Draw(Camera cam)
        {
            Matrix[] bones = animationPlayer.GetSkinTransforms();
            boneTransformations = new Matrix[model.Bones.Count];

            model.CopyAbsoluteBoneTransformsTo(boneTransformations);

            // Render the skinned mesh.
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (ModelMeshPart p in mesh.MeshParts)
                {
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
                        * Matrix.CreateFromAxisAngle(Vector3.UnitX, gameObject.Transform.Rotation.X)
                        * Matrix.CreateFromAxisAngle(Vector3.UnitY, gameObject.Transform.Rotation.Y)
                        * Matrix.CreateFromAxisAngle(Vector3.UnitZ, gameObject.Transform.Rotation.Z)
                        * Matrix.CreateTranslation(gameObject.Transform.Position)
                        * Matrix.CreateScale(scale);

                    effect.Parameters["Bones"]?.SetValue(bones);
                    effect.Parameters["BoneCount"]?.SetValue(bones.Length);

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

                    effect.CurrentTechnique = effect.Techniques["Skinned"];
                }

                mesh.Draw();
            }
        }

        //public Matrix GetMatrix()
        //{
        //    return Matrix.CreateScale(scale)
        //                * Matrix.CreateFromQuaternion(gameObject.Transform.quaterion)
        //                * Matrix.CreateScale(scale)
        //                * Matrix.CreateTranslation(gameObject.Transform.Position)
        //                * Matrix.CreateTranslation(gameObject.Transform.origin);
        //}

    }
}


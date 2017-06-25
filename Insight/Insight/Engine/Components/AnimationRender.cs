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
        public enum AnimationModel
        {
            Player,
            Enemy
        }
        //Model model;
        //Matrix[] boneTransformations;
        List<AnimationClip> clips = new List<AnimationClip>();
        AnimationPlayer animationPlayer;

        public int animationId { get; private set; }
        //float scale;
        public AnimationRender(GameObject gameObject) : base(gameObject)
        {

            scale = 1.0f;
        }

        public override void Load(ContentManager c)
        {
            model = ContentModels.Instance.playerRun;
            effect = Material.GetEffect();
            SkinningData skinningData = model.Tag as SkinningData;

            if (skinningData == null)
                throw new InvalidOperationException
                    ("This model does not contain a SkinningData tag.");

            animationPlayer = new AnimationPlayer(skinningData);

            AnimationClip clip = skinningData.AnimationClips["Take 001"];

            animationPlayer.StartClip(clip, 300);
        }

        //public void LoadNewModel(Model model, Model model2)
        //{
        //    this.model = model;
        //    effect = Material.GetEffect();
        //    SkinningData skinningData = model.Tag as SkinningData;

        //    if (skinningData == null)
        //        throw new InvalidOperationException
        //            ("This model does not contain a SkinningData tag.");

        //    animationPlayer = new AnimationPlayer(skinningData);

        //    AnimationClip clip = skinningData.AnimationClips["Take 001"];


        //    SkinningData skinningData2 = model2.Tag as SkinningData;

        //    if (skinningData2 == null)
        //        throw new InvalidOperationException
        //            ("This model does not contain a SkinningData tag.");

        //    AnimationPlayer animationPlayer2 = new AnimationPlayer(skinningData2);

        //    AnimationClip clip2 = skinningData2.AnimationClips["Take 001"];

        //    clips.Add(clip);
        //    clips.Add(clip2);

        //    animationPlayer.StartClip(clip, 30);
        //}

        public void Load(ContentManager c, AnimationModel animModel)
        {
            if(animModel == AnimationModel.Player)
            {
                this.model = ContentModels.Instance.playerIdle;
                effect = Material.GetEffect();
                SkinningData skinningData = model.Tag as SkinningData;

                if (skinningData == null)
                    throw new InvalidOperationException
                        ("This model does not contain a SkinningData tag.");

                animationPlayer = new AnimationPlayer(skinningData);

                AnimationClip clip = skinningData.AnimationClips["mixamo.com"];
  
                clips.Add(NewClip(ContentModels.Instance.playerIdle));
                clips.Add(NewClip(ContentModels.Instance.playerRun));
                clips.Add(NewClip(ContentModels.Instance.playerDeath));
                clips.Add(NewClip(ContentModels.Instance.playerWalkF));//3
                clips.Add(NewClip(ContentModels.Instance.playerWalkB));//4
                clips.Add(NewClip(ContentModels.Instance.playerWalkR));//5
                clips.Add(NewClip(ContentModels.Instance.playerWalkL));//6
                clips.Add(NewClip(ContentModels.Instance.playerFistFight));//7
                animationPlayer.StartClip(clips[0], 400);
            }
            if(animModel == AnimationModel.Enemy)
            {
                this.model = ContentModels.Instance.enemyWalkF;
                effect = Material.GetEffect();
                SkinningData skinningData = ContentModels.Instance.enemyWalkF.Tag as SkinningData;

                if (skinningData == null)
                    throw new InvalidOperationException
                        ("This model does not contain a SkinningData tag.");

                animationPlayer = new AnimationPlayer(skinningData);

                AnimationClip clip = skinningData.AnimationClips["mixamo.com"];

                clips.Add(NewClip(ContentModels.Instance.enemyIdle));//0
                clips.Add(NewClip(ContentModels.Instance.enemyWalkF));//1
                clips.Add(NewClip(ContentModels.Instance.enemyDeath));//2
                clips.Add(NewClip(ContentModels.Instance.enemyAggresive));//3
                clips.Add(NewClip(ContentModels.Instance.enemyFight));//4
                clips.Add(NewClip(ContentModels.Instance.enemyParalysis));//5
                clips.Add(NewClip(ContentModels.Instance.enemyMarker));//5
                animationPlayer.StartClip(clips[0], 400);
            }
        }

        public AnimationClip NewClip(Model model)
        {
            SkinningData skinningData3 = model.Tag as SkinningData;

            if (skinningData3 == null)
                throw new InvalidOperationException
                    ("This model does not contain a SkinningData tag.");

            AnimationPlayer animationPlayer3 = new AnimationPlayer(skinningData3);

            AnimationClip clip3 = skinningData3.AnimationClips["mixamo.com"];
            return clip3;
        }

        public AnimationClip GetCurrentClip()
        {
            return animationPlayer.CurrentClip;
        }

        public void ChangeAnimation(int id, bool loop)
        {
            animationId = id;
            animationPlayer.StartClip(clips[id], 400, loop);
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


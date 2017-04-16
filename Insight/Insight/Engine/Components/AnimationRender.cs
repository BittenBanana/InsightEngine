using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SkinnedModel;
using System;

namespace Insight.Engine.Components
{
    class AnimationRender : Component
    {
        Model model;
        Texture2D texture;
        Matrix[] boneTransformations;

        AnimationPlayer animationPlayer;
        float scale;

        public AnimationRender(GameObject gameObject) : base(gameObject)
        {

            scale = 0.1f;
        }

        public void Load(ContentManager c)
        {
            model = c.Load<Model>("worek");

            SkinningData skinningData = model.Tag as SkinningData;

            if (skinningData == null)
                throw new InvalidOperationException
                    ("This model does not contain a SkinningData tag.");

            animationPlayer = new AnimationPlayer(skinningData);

            AnimationClip clip = skinningData.AnimationClips["Take 001"];

            animationPlayer.StartClip(clip);
        }
        

        public Model getModel()
        {
            return model;
        }

        public float GetScale()
        {
            return scale;
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
                foreach (SkinnedEffect effect in mesh.Effects)
                {
                    effect.World = boneTransformations[mesh.ParentBone.Index]
                        * Matrix.CreateScale(scale)
                        * Matrix.CreateFromQuaternion(gameObject.Transform.quaterion)
                        * Matrix.CreateTranslation(gameObject.Transform.Position)
                        * Matrix.CreateTranslation(gameObject.Transform.origin);


                    effect.SetBoneTransforms(bones);
                    
                    effect.View = cam.view;
                    effect.Projection = cam.projection;

                    effect.EnableDefaultLighting();

                    effect.SpecularColor = new Vector3(0.25f);
                    effect.SpecularPower = 16;
                }

                mesh.Draw();
            }
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


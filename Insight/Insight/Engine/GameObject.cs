﻿using Insight.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine
{
    public class GameObject
    {
        private List<Component> components;

        public string Name { get; set; }
        public Transform Transform { get; set; }
        public MeshRenderer Mesh { get; set; }
        public string Tag { get; set; }

        //Temp
        public Model meshModel;
        public Matrix[] boneTransformations;

        float velocity = 5f;

        public GameObject()
        {
            components = new List<Component>();
            Transform = new Transform(this);
        }
        public GameObject(Vector3 pos)
        {
            components = new List<Component>();
            Transform = new Transform(this, pos);
        }

        public void AddNewComponent<T>() where T : Component
        {
            if (typeof(T) == typeof(Transform) && Transform == null)
            {
                Transform = new Transform(this);
            }
            else if (typeof(T) != typeof(Transform))
            {
                T newComp = Activator.CreateInstance(typeof(T), this) as T;
                components.Add(newComp);
            }
            Console.WriteLine("Cannot add multiple transforms");
        }

        public void AddComponent(Component comp)
        {
            if (comp.GetType() != typeof(Transform))
            {
                components.Add(comp);
            }
        }

        public T GetComponent<T>()
        {
            return components.OfType<T>().FirstOrDefault();
        }

        public void LoadContent(ContentManager c)
        {
            //Mesh.Load();
            meshModel = c.Load<Model>("GameObject/boxMat");
        }

        public void Update()
        {
            foreach (var item in components)
            {
                item.Update();
            }
        }

        public void Draw(Camera camera)
        {
            boneTransformations = new Matrix[meshModel.Bones.Count];
            meshModel.CopyAbsoluteBoneTransformsTo(boneTransformations);

            foreach (ModelMesh mesh in meshModel.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = boneTransformations[mesh.ParentBone.Index] * Matrix.CreateScale(2f) * Matrix.CreateRotationX(Transform.Rotation.X) * Matrix.CreateRotationY(Transform.Rotation.Y) * Matrix.CreateRotationZ(Transform.Rotation.Z) * Matrix.CreateTranslation(Transform.Position);
                    effect.View = camera.view;
                    effect.Projection = camera.projection;
                    effect.EnableDefaultLighting();
                }
                mesh.Draw();
            }
        }
    }
}

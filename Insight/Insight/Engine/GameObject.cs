using Insight.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public string Tag { get; set; }
        public float velocityX;
        public float velocityZ;
        bool collision;
        bool isDynamic;
        public Layer physicLayer { get; set; }

        //temp
        public bool isCube;

        public GameObject(bool isDynamic)
        {
            components = new List<Component>();
            Transform = new Transform(this);
            this.isDynamic = isDynamic;
            
        }
        public GameObject(Vector3 position, bool isDynamic)
        {
            components = new List<Component>();
            Transform = new Transform(this, position);
            this.isDynamic = isDynamic;
        }
        
        public void AddNewComponent<T>() where T : Component
        {
            if (typeof(T) != typeof(Transform))
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
            if (GetComponent<MeshRenderer>() != null)
            {
                GetComponent<MeshRenderer>().Load(c);
            }
        }

        public void Update()
        {
            if(!collision)
            {
                velocityX = 1f * (float)Math.Sin(Transform.Rotation.Y);
                velocityZ = 1f * (float)Math.Cos(Transform.Rotation.Y);
            }
            
            foreach (var item in components)
            {
                item.Update();
            }
        }

        public void Draw(Camera camera)
        {
            if(GetComponent<MeshRenderer>() != null)
            {
                GetComponent<MeshRenderer>().Draw(camera);
            }
        }

        public void OnObjectColided(object source, CollisionEventArgs args)
        {
            velocityX = 0;
            velocityZ = 0;
            collision = true;
            //Transform.Position = args.LastPosition - new Vector3(0.8f, 0, 0.8f);
            //Transform.Position -= Matrix.CreateFromAxisAngle(Transform.Rotation, Transform.Rotation.Y).Backward;
            Debug.WriteLine(args.GameObject.physicLayer);
            if(args.GameObject.physicLayer != Layer.Ground && this.physicLayer == Layer.Ground)
            {
                Transform.Position.X -= 1f * (float)Math.Sin(Transform.Rotation.Y);
                Transform.Position.Z -= 1f * (float)Math.Cos(Transform.Rotation.Y);
            }
            
            Transform.Position.Y -= GetComponent<Rigidbody>().velocity.Y * Time.deltaTime;
            collision = false;
        }

        public bool IsDynamic()
        {
            return isDynamic;
        }
    }
}

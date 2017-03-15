using Insight.Engine.Components;
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
        public string Tag { get; set; }

        //Temp
        public Model meshModel;
        public Matrix[] boneTransformations;


        public GameObject()
        {
            components = new List<Component>();
            Transform = new Transform(this);
        }
        public GameObject(Vector3 position)
        {
            components = new List<Component>();
            Transform = new Transform(this, position);
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
    }
}

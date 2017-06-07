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
using System.Timers;

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
        public float rotationSpeed;
        bool collision;
        bool isDynamic;
        public Layer physicLayer { get; set; }
        public event EventHandler<CollisionEventArgs> EnterTriggerActivated;
        public event EventHandler<CollisionEventArgs> StayTriggerActivated;
        public event EventHandler<CollisionEventArgs> ExitTriggerActivated;
        public event EventHandler<CollisionEventArgs> EnterCollisionActivated;
        public event EventHandler<CollisionEventArgs> ExitCollisionActivated;
        public bool Forward { get; set; }
        public bool Backward { get; set; }
        public bool Right { get; set; }
        public bool Left { get; set; }
        public bool IsMoving { get; set; }
        public bool IsRotating { get; set; }
        public Vector3 nextPosition;

        //temp
        public bool isCube;

        public GameObject(bool isDynamic)
        {
            components = new List<Component>();
            Transform = new Transform(this);
            components.Add(Transform);
            this.isDynamic = isDynamic;
            rotationSpeed = .05f;
            nextPosition = new Vector3(0);
        }
        public GameObject(Vector3 position, bool isDynamic)
        {
            components = new List<Component>();
            Transform = new Transform(this, position);
            components.Add(Transform);
            this.isDynamic = isDynamic;
            nextPosition = new Vector3(0);

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
            else if (GetComponent<AnimationRender>() != null)
            {
                GetComponent<AnimationRender>().Load(c);
            }
        }
        public void LoadContent(ContentManager c, Model model, float scale)
        {
            if (GetComponent<MeshRenderer>() != null)
            {
                GetComponent<MeshRenderer>().Load(c, model, scale);
            }
        }

        public void Update()
        {
            if (!collision)
            {
                
                velocityX = 0.1f * (float)Math.Sin(Transform.Rotation.Y);
                velocityZ = 0.1f * (float)Math.Cos(Transform.Rotation.Y);
            }

            foreach (var item in components)
            {
                item.Update();
            }

            
        }

        public void Draw(Camera camera)
        {
            //if (GetComponent<MeshRenderer>() != null)
            //{
            //    GetComponent<MeshRenderer>().Draw(camera);
            //}
            foreach (Component item in components)
            {
                item.Draw(camera);
            }
        }

        public void OnObjectColided(object source, CollisionEventArgs args)
        {
            nextPosition.X = Transform.Position.X + 0.1f * (float)Math.Sin(Transform.Rotation.Y);
            nextPosition.Z = Transform.Position.Z + 0.1f * (float)Math.Cos(Transform.Rotation.Y);
            velocityX = 0;
            velocityZ = 0;
            collision = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            //Transform.Position = args.LastPosition - new Vector3(0.8f, 0, 0.8f);
            //Transform.Position -= Matrix.CreateFromAxisAngle(Transform.Rotation, Transform.Rotation.Y).Backward;
            //Debug.WriteLine(args.GameObject.physicLayer);
            if (this.physicLayer == Layer.Player && args.GameObject.GetComponent<Collider>() != null)
            {
                if (args.GameObject.physicLayer != Layer.Ground && !args.GameObject.GetComponent<Collider>().IsTrigger)
                {
                    if (rb != null)
                    {
                        rb.isGrounded = false;
                    }
                    if (args.GameObject.physicLayer != Layer.Stairs)
                    {
                        if (Forward)
                        {
                            Transform.Position.X -= 0.1f * (float)Math.Sin(Transform.Rotation.Y);
                            Transform.Position.Z -= 0.1f * (float)Math.Cos(Transform.Rotation.Y);
                            //rotationSpeed = 0;
                        }



                        if (Backward)
                        {
                            Transform.Position.X += 0.1f * (float)Math.Sin(Transform.Rotation.Y);
                            Transform.Position.Z += 0.1f * (float)Math.Cos(Transform.Rotation.Y);
                            //rotationSpeed = 0;
                        }

                        if (Left)
                        {
                            

                            if ((float)Math.Sin(Transform.Rotation.Y) > -0.75f && (float)Math.Sin(Transform.Rotation.Y) < 0.75f && (float)Math.Cos(Transform.Rotation.Y) < -0.66f) 
                            {
                                Transform.Position.X += 0.1f;
                            }
                            else if((float)Math.Sin(Transform.Rotation.Y) > 0.75f && (float)Math.Cos(Transform.Rotation.Y) > -0.65f && (float)Math.Cos(Transform.Rotation.Y) < 0.65f)
                            {
                                Transform.Position.Z += 0.1f;
                            }
                            else if((float)Math.Sin(Transform.Rotation.Y) < -0.75f && (float)Math.Cos(Transform.Rotation.Y) < 0.65f && (float)Math.Cos(Transform.Rotation.Y) > -0.65f)
                            {
                                Transform.Position.Z -= 0.1f;
                            }
                            else
                            {
                                Transform.Position.X -= 0.1f;
                            }

                            //Transform.Position.Z -= 0.1f * (float)Math.Cos(Transform.Rotation.Y);
                            rotationSpeed = 0;
                        }

                        if (Right)
                        {
                            if ((float)Math.Sin(Transform.Rotation.Y) > -0.75f && (float)Math.Sin(Transform.Rotation.Y) < 0.75f && (float)Math.Cos(Transform.Rotation.Y) < -0.66f)
                            {
                                Transform.Position.X -= 0.1f;
                            }
                            else if ((float)Math.Sin(Transform.Rotation.Y) > 0.75f && (float)Math.Cos(Transform.Rotation.Y) > -0.65f && (float)Math.Cos(Transform.Rotation.Y) < 0.65f)
                            {
                                Transform.Position.Z -= 0.1f;
                            }
                            else if ((float)Math.Sin(Transform.Rotation.Y) < -0.75f && (float)Math.Cos(Transform.Rotation.Y) < 0.65f && (float)Math.Cos(Transform.Rotation.Y) > -0.65f)
                            {
                                Transform.Position.Z += 0.1f;
                            }
                            else
                            {
                                Transform.Position.X += 0.1f;
                            }
                            
                            //Transform.Position.Z -= 0.1f * (float)Math.Cos(Transform.Rotation.Y);
                            rotationSpeed = 0;
                        }

                        //Transform.Position = nextPosition - Transform.Position;

                    }
                }

                if(args.GameObject.physicLayer == Layer.Stairs)
                {
                    if(this.IsMoving)
                    {
                        Debug.WriteLine("stairsssssss");
                        this.Transform.Position.Y += 0.8f;
                        //GetComponent<Rigidbody>().useGravity = false;
                    }
                    else
                    {
                        Transform.Position.Y -= GetComponent<Rigidbody>().velocity.Y * Time.deltaTime;
                    }
                    
                }

                
                if (rb != null)
                {
                    if (args.GameObject.physicLayer == Layer.Ground && !rb.isGrounded)
                    {
                        rb.isGrounded = true;
                    }
                }
            }

            if (args.GameObject.physicLayer != Layer.Enemy && this.physicLayer != Layer.Enemy)
            {
                if (args.GameObject.GetComponent<Collider>().IsTrigger || this.GetComponent<Collider>().IsTrigger)
                {

                    if (GetComponent<Collider>().OnTriggerEnter == false)
                    {
                        OnTriggerEnter(args.GameObject);
                        GetComponent<Collider>().OnTriggerEnter = true;
                    }

                    OnTriggerStay(args.GameObject);

                    if (GetComponent<Collider>().OnTriggerExit)
                    {
                        //OnTriggerExit(args.GameObject);
                    }

                }
            }
            

            //if (GetComponent<Collider>().OnCollisionEnter == false)
            //{
            //    OnCollisionEnter(args.GameObject);
            //    GetComponent<Collider>().OnCollisionEnter = true;
            //}



            collision = false;
        }

        public bool IsDynamic()
        {
            return isDynamic;
        }

        protected virtual void OnTriggerEnter(GameObject gameObject)
        {
            if (EnterTriggerActivated != null)
                EnterTriggerActivated(this, new CollisionEventArgs() { GameObject = gameObject });
        }

        protected virtual void OnTriggerStay(GameObject gameObject)
        {
            if (StayTriggerActivated != null)
                StayTriggerActivated(this, new CollisionEventArgs() { GameObject = gameObject });
        }

        public virtual void OnTriggerExit(GameObject gameObject)
        {
            if (ExitTriggerActivated != null)
                ExitTriggerActivated(this, new CollisionEventArgs() { GameObject = gameObject });
        }

        protected virtual void OnCollisionEnter(GameObject gameObject)
        {
            if (EnterCollisionActivated != null)
                EnterCollisionActivated(this, new CollisionEventArgs() { GameObject = gameObject });
        }

        public virtual void OnCollisionExit(GameObject gameObject)
        {
            if (ExitCollisionActivated != null)
                ExitCollisionActivated(this, new CollisionEventArgs() { GameObject = gameObject });
        }

        private void myEvent(object source, ElapsedEventArgs e)
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Insight.Engine.Components
{
    class Rigidbody : Component
    {
        public Vector3 velocity { get; set; }
        public float mass { get; set; }
        public bool useGravity { get; set; }

        private Vector3 newAcceleration;
        private Vector3 lastAcceleration;
        private Vector3 avgAcceleration;
        Physics.RaycastHit hit;
        public bool isGrounded;

        public Rigidbody(GameObject gameObject) : base(gameObject)
        {
            useGravity = true;
            mass = 1.0f;
        }

        public void AddForce(Vector3 force)
        {
            lastAcceleration = newAcceleration;
            gameObject.Transform.Position += velocity * Time.deltaTime;
            newAcceleration = force / mass;
            avgAcceleration = (lastAcceleration + newAcceleration) / 2;
            velocity += avgAcceleration * Time.deltaTime;          
        }

        public override void Update()
        {
            if (useGravity)
            {
                
                Physics.Raycast(gameObject.Transform.Position, Vector3.Normalize(Physics.Gravity), out hit);
                if (hit != null)
                {
                    if (hit.distance > 3)
                    {
                        Debug.WriteLine("Gravity working " + hit.distance);
                        velocity += Physics.Gravity * Time.deltaTime;
                        gameObject.Transform.Position += velocity * Time.deltaTime;
                        isGrounded = false;
                    }
                    else if(!isGrounded)
                    {
                        velocity = Vector3.Zero;
                        isGrounded = true;
                    }
                }
                else
                {
                    velocity += Physics.Gravity * Time.deltaTime;
                    gameObject.Transform.Position += velocity * Time.deltaTime;
                    isGrounded = false;
                }
            }
            base.Update();
        }
    }
}

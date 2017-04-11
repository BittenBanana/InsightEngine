using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

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
                velocity += Physics.Gravity * Time.deltaTime;
                gameObject.Transform.Position += velocity * Time.deltaTime;
            }
            base.Update();
        }
    }
}

﻿using Insight.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Scripts
{
    public abstract class BaseScript : Component
    {
        public BaseScript(GameObject gameObject) : base (gameObject)
        {
            gameObject.EnterTriggerActivated += OnTriggerEnter;
            gameObject.StayTriggerActivated += OnTriggerStay;
            gameObject.ExitTriggerActivated += OnTriggerExit;
            gameObject.EnterCollisionActivated += OnCollisionEnter;
            gameObject.ExitCollisionActivated += OnCollisionExit;
        }

        public virtual void OnTriggerEnter(object source, CollisionEventArgs args)
        {
            
        }

        public virtual void OnTriggerStay(object source, CollisionEventArgs args)
        {
            
        }

        public virtual void OnTriggerExit(object source, CollisionEventArgs args)
        {
            
        }

        public virtual void OnCollisionEnter(object source, CollisionEventArgs args)
        {

        }

        public virtual void OnCollisionExit(object source, CollisionEventArgs args)
        {

        }
    }
}

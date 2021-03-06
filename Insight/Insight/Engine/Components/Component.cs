﻿using Microsoft.Xna.Framework;
using System;
using System.Collections;

namespace Insight.Engine
{
    abstract public class Component
    {
        public string Name { get; set; }
        public GameObject gameObject { get; private set; }
        public Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(Camera cam)
        {

        }
    }
}
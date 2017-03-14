using System;
using System.Collections;

namespace Insight.Engine
{
    public class Component
    {
        public string Name { get; set; }
        public GameObject gameObject { get; private set; }
        public Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}
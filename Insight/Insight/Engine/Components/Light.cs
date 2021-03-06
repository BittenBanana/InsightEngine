﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Insight.Engine.Components
{
    public class Light : Component
    {
        private float _intensity;
        private Vector3 _direction;
        public Color Color { get; set; }

        public Vector3 Direction
        {
            get { return _direction; }
            set
            {
                _direction = Vector3.Normalize(value);
            }
        }

        public float Intensity
        {
            get { return _intensity; }
            set
            {
                if (value <= 0)
                {
                    _intensity = 0;
                }
                else
                {
                    _intensity = value;
                }
            }
        }

        public float Attenuation { get; set; }

        public Light(GameObject gameObject) : base(gameObject)
        {
            Color = Color.White;
            Intensity = 1f;
            Direction = new Vector3(0.3f,-0.5f, 0);
            Attenuation = 5;
        }
    }
}

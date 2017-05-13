using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Insight.Engine.Components
{
    class Light : Component
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
                else if (value >= 1)
                {
                    _intensity = 1;
                }
                else
                {
                    _intensity = value;
                }
            }
        }


        public Light(GameObject gameObject) : base(gameObject)
        {
            Color = Color.White;
            Intensity = 0.5f;
            Direction = new Vector3(0.3f,-0.5f, 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;

namespace Insight.Scripts
{
    class EnemySight : BaseScript
    {
        public Transform followTransform { get; set; }
        public EnemySight(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Update()
        {
            gameObject.Transform.Position = followTransform.Position;
            base.Update();
        }

        public override void OnTriggerStay(object source, CollisionEventArgs args)
        {
            if (args.GameObject.physicLayer == Layer.Player)
            {
                Debug.WriteLine("Player InSight");
            }

        }
    }
}

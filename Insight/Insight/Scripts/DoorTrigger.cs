using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;

namespace Insight.Scripts
{
    class DoorTrigger : BaseScript
    {
        public DoorAnimation targetAnimation { get; set; }
        public DoorTrigger(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnTriggerEnter(object source, CollisionEventArgs args)
        {
            if (args.GameObject.physicLayer == Layer.Player || args.GameObject.physicLayer == Layer.Enemy)
            {
                if (targetAnimation != null)
                    targetAnimation.OpenDoor();
            }
        }

        public override void OnTriggerExit(object source, CollisionEventArgs args)
        {
            if (args.GameObject.physicLayer == Layer.Player || args.GameObject.physicLayer == Layer.Enemy)
            {
                if(targetAnimation != null)
                    targetAnimation.CloseDoor();
            }
        }

    }
}

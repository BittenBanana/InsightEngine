using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Insight.Scenes;

namespace Insight.Scripts
{
    class EndGameController : BaseScript
    {
        public EndGameController(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnTriggerEnter(object source, CollisionEventArgs args)
        {
            base.OnTriggerEnter(source, args);
            if (args.GameObject.physicLayer == Layer.Player)
            {
                DemoScene demo = (DemoScene)SceneManager.Instance.currentScene;
                demo.PlayDialogThree();
            }
        }

    }
}

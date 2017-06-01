using Insight.Engine;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Scripts
{
    class DispenserTriggerController : BaseScript
    {
        public DispenserTriggerController(GameObject gameObject) : base(gameObject)
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnTriggerEnter(object source, CollisionEventArgs args)
        {
            if (args.GameObject.physicLayer == Layer.Player)
            {
                Debug.WriteLine("dispenser");
                SceneManager.Instance.currentScene.ui.ChangeSpriteOpacity("bulletRakieta", 1);
                SceneManager.Instance.currentScene.ui.ChangeTextOpacity("dispenserHint", 1);
            }
        }

        public override void OnTriggerStay(object source, CollisionEventArgs args)
        {
            if (args.GameObject.physicLayer == Layer.Player)
            {
                KeyboardState keyState = Keyboard.GetState();
                if (keyState.IsKeyDown(Keys.E))
                {
                    args.GameObject.GetComponent<PlayerBullets>().aggresiveBullet = true;
                }
            }


        }

        public override void OnTriggerExit(object source, CollisionEventArgs args)
        {
            if (args.GameObject.physicLayer == Layer.Player)
            {
                SceneManager.Instance.currentScene.ui.ChangeSpriteOpacity("bulletRakieta", 0);
                SceneManager.Instance.currentScene.ui.ChangeTextOpacity("dispenserHint", 0);
            }

        }
    }
}

using Insight.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Scripts
{
    class IntercomController : BaseScript
    {
        bool isUsed = false;
        public GameObject doors { get; set; }
        public ContentManager content { get; set; }
        public IntercomController(GameObject gameObject) : base(gameObject)
        {
        }
        public override void Update()
        {
            base.Update();
        }

        public override void OnTriggerEnter(object source, CollisionEventArgs args)
        {
            base.OnTriggerEnter(source, args);
            Debug.WriteLine("entered");
            if (args.GameObject.physicLayer == Layer.Player && isUsed == false && doors != null)
            {
                SceneManager.Instance.currentScene.ui.ChangeTextOpacity("doorHint", 1);
            }
        }

        public override void OnTriggerStay(object source, CollisionEventArgs args)
        {
            base.OnTriggerStay(source, args);
            if (args.GameObject.physicLayer == Layer.Player && isUsed == false && doors != null)
            {
                KeyboardState keyState = Keyboard.GetState();
                if (keyState.IsKeyDown(Keys.E))
                {
                    doors.GetComponent<DoorAnimation>().canOpen = true;
                    isUsed = true;
                    SceneManager.Instance.currentScene.ui.ChangeTextOpacity("doorHint", 0);
                }
            }
        }

        public override void OnTriggerExit(object source, CollisionEventArgs args)
        {
            base.OnTriggerExit(source, args);

            if (args.GameObject.physicLayer == Layer.Player)
            {
                SceneManager.Instance.currentScene.ui.ChangeTextOpacity("doorHint", 0);
            }
        }
    }
}

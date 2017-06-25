using Insight.Engine;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine.Components;
using Microsoft.Xna.Framework.Content;

namespace Insight.Scripts
{
    class DispenserTriggerController : BaseScript
    {
        bool isEmpty;
        public GameObject dispenser { get; set; }
        public ContentManager content { get; set; }
        public DispenserTriggerController(GameObject gameObject) : base(gameObject)
        {
            isEmpty = false;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnTriggerEnter(object source, CollisionEventArgs args)
        {
            if (args.GameObject.physicLayer == Layer.Player && isEmpty == false)
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
                if (keyState.IsKeyDown(Keys.E) && isEmpty == false)
                {
                    dispenser.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/czerwoneSwiatelko/ammo-pc_DefaultMaterial_AO");
                    dispenser.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/czerwoneSwiatelko/ammo-pc_DefaultMaterial_MetallicSmoothness");
                    dispenser.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/czerwoneSwiatelko/ammo-pc_DefaultMaterial_Normal");
                    dispenser.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/czerwoneSwiatelko/ammo-pc_DefaultMaterial_AlbedoTransparency");
                    args.GameObject.GetComponent<PlayerBullets>().aggresiveBullet = true;
                    isEmpty = true;
                    SceneManager.Instance.currentScene.ui.ChangeSpriteOpacity("bulletRakieta", 0);
                    SceneManager.Instance.currentScene.ui.ChangeTextOpacity("dispenserHint", 0);
                    if (args.GameObject.GetComponent<RaycastTest>().GetLoadedBullet() == null)
                    {
                        if (args.GameObject.GetComponent<PlayerBullets>().paralysisBullet == true)
                        {
                            args.GameObject.GetComponent<RaycastTest>().SetBulletLoad(PlayerBullets.Bullets.Paralysis);
                        }
                        else if (args.GameObject.GetComponent<PlayerBullets>().transmitterBullet == true)
                        {
                            args.GameObject.GetComponent<RaycastTest>().SetBulletLoad(PlayerBullets.Bullets.Transmitter);
                        }
                        else if (args.GameObject.GetComponent<PlayerBullets>().aggresiveBullet == true)
                        {
                            args.GameObject.GetComponent<RaycastTest>().SetBulletLoad(PlayerBullets.Bullets.Agressive);
                        }
                    }
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

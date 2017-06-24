using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;
using Insight.Scenes;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using Microsoft.Xna.Framework.Input;
using Insight.Engine.Components;
using Insight.Materials;
using Insight.Scripts.EnemyStates;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Insight.Scripts
{
    class RaycastTest : BaseScript
    {
        Physics.RaycastHit hit;

        bool isPressed = false;

        private GameObject test;

        int previousScrollValue;

        MouseState ms;

        private PlayerBullets.Bullets? currentBulletLoaded;

        private List<SoundEffectInstance> sounds;
        private Random rand;

        public RaycastTest(GameObject gameObject) : base(gameObject)
        {
            currentBulletLoaded = null;
            previousScrollValue = ms.ScrollWheelValue;
            rand = new Random();
            sounds = new List<SoundEffectInstance>();
            sounds.Add(SceneManager.Instance.currentScene.audioManager.AddSoundEffectWithEmitter("Audio/shoot1", gameObject));
            sounds.Add(SceneManager.Instance.currentScene.audioManager.AddSoundEffectWithEmitter("Audio/shoot2", gameObject));
            sounds.Add(SceneManager.Instance.currentScene.audioManager.AddSoundEffectWithEmitter("Audio/shoot3", gameObject));
            SceneManager.Instance.currentScene.audioManager.PlaySoundEffect(sounds[rand.Next(0, 2)]);
        }

        public override void Update()
        {
            ms = Mouse.GetState();

            #region LeftButton
            if (ms.LeftButton == ButtonState.Pressed && !isPressed && currentBulletLoaded != null)
            {
                SceneManager.Instance.currentScene.audioManager.PlaySoundEffect(sounds[rand.Next(0,2)]);
                //am.PlaySoundEffect(0);
                Vector3 minPoint = SceneManager.Instance.device.GraphicsDevice.Viewport.Unproject(
                    new Vector3(SceneManager.Instance.device.GraphicsDevice.Viewport.Width / 2,
                        SceneManager.Instance.device.GraphicsDevice.Viewport.Height / 2,
                        0),
                    SceneManager.Instance.currentScene.GetProjectionMatrix(),
                    SceneManager.Instance.currentScene.GetMainCamera().view,
                    Matrix.Identity);

                Vector3 maxPoint = SceneManager.Instance.device.GraphicsDevice.Viewport.Unproject(
                    new Vector3(SceneManager.Instance.device.GraphicsDevice.Viewport.Width / 2,
                        SceneManager.Instance.device.GraphicsDevice.Viewport.Height / 2,
                        1),
                    SceneManager.Instance.currentScene.GetProjectionMatrix(),
                    SceneManager.Instance.currentScene.GetMainCamera().view,
                    Matrix.Identity);

                Vector3 direction = maxPoint - minPoint;

                direction.Normalize();

                Debug.WriteLine(direction);
                if (Physics.Raycast(minPoint, direction, out hit))
                {
                    isPressed = true;
                    Physics.RaycastHit tempHit = hit;
                    while (Vector3.Distance(minPoint, tempHit.point) < Vector3.Distance(minPoint, gameObject.Transform.Position + direction) && hit != null)
                    {

                        if (Physics.Raycast(tempHit.point + direction, direction, out hit))
                        {
                            tempHit = hit;
                        }

                    }
                    if (hit != null)
                    {
                        //test = new GameObject(hit.point, false);
                        //test.AddNewComponent<MeshRenderer>();

                        //Effect e = SceneManager.Instance.Content.Load<Effect>("Shaders/PhongBlinnShader");
                        //test.GetComponent<MeshRenderer>().Material = new DefaultMaterial(e);
                        //test.GetComponent<MeshRenderer>().Load(SceneManager.Instance.Content);


                        //Debug.WriteLine("Hit!" + " " + hit.collider.gameObject + " " + hit.distance);

                        if (hit.collider.gameObject.physicLayer == Layer.Enemy)
                        {
                            if(!(hit.collider.gameObject.GetComponent<EnemyAI>().currentState is DeathState))
                            switch (currentBulletLoaded)
                            {
                                case PlayerBullets.Bullets.Agressive:
                                    hit.collider.gameObject.GetComponent<EnemyAI>().ChangeState(new TransitionState(), new AgressiveState());
                                    break;
                                case PlayerBullets.Bullets.Transmitter:
                                    hit.collider.gameObject.GetComponent<EnemyAI>().ChangeState(new TransitionState(), new FollowMarkerState());
                                    break;
                                case PlayerBullets.Bullets.Paralysis:
                                    hit.collider.gameObject.GetComponent<EnemyAI>().ChangeState(new ParalysisState());
                                    break;
                            }
                        }

                        if (currentBulletLoaded == null)
                        {
                            if (gameObject.GetComponent<PlayerBullets>().paralysisBullet)
                            {
                                gameObject.GetComponent<RaycastTest>().SetBulletLoad(PlayerBullets.Bullets.Paralysis);
                            }
                            else if (gameObject.GetComponent<PlayerBullets>().transmitterBullet)
                            {
                                gameObject.GetComponent<RaycastTest>().SetBulletLoad(PlayerBullets.Bullets.Transmitter);
                            }
                            else if (gameObject.GetComponent<PlayerBullets>().aggresiveBullet)
                            {
                                gameObject.GetComponent<RaycastTest>().SetBulletLoad(PlayerBullets.Bullets.Agressive);
                            }
                        }
                    }
                }
                switch (currentBulletLoaded)
                {
                    case PlayerBullets.Bullets.Agressive:
                        gameObject.GetComponent<PlayerBullets>().aggresiveBullet = false;
                        currentBulletLoaded = null;
                        break;
                    case PlayerBullets.Bullets.Transmitter:
                        gameObject.GetComponent<PlayerBullets>().transmitterBullet = false;
                        currentBulletLoaded = null;
                        break;
                    case PlayerBullets.Bullets.Paralysis:
                        gameObject.GetComponent<PlayerBullets>().paralysisBullet = false;
                        currentBulletLoaded = null;
                        break;
                }
                isPressed = true;
            }

            if (ms.LeftButton == ButtonState.Released)
            {
                isPressed = false;
            }
            #endregion

            #region RightButton

            if (ms.RightButton == ButtonState.Pressed && !isPressed && currentBulletLoaded == PlayerBullets.Bullets.Transmitter)
            {
                Vector3 minPoint = SceneManager.Instance.device.GraphicsDevice.Viewport.Unproject(
                    new Vector3(SceneManager.Instance.device.GraphicsDevice.Viewport.Width / 2,
                        SceneManager.Instance.device.GraphicsDevice.Viewport.Height / 2,
                        0),
                    SceneManager.Instance.currentScene.GetProjectionMatrix(),
                    SceneManager.Instance.currentScene.GetMainCamera().view,
                    Matrix.Identity);

                Vector3 maxPoint = SceneManager.Instance.device.GraphicsDevice.Viewport.Unproject(
                    new Vector3(SceneManager.Instance.device.GraphicsDevice.Viewport.Width / 2,
                        SceneManager.Instance.device.GraphicsDevice.Viewport.Height / 2,
                        1),
                    SceneManager.Instance.currentScene.GetProjectionMatrix(),
                    SceneManager.Instance.currentScene.GetMainCamera().view,
                    Matrix.Identity);

                Vector3 direction = maxPoint - minPoint;

                direction.Normalize();

                Debug.WriteLine(direction);
                if (Physics.Raycast(minPoint, direction, out hit))
                {
                    isPressed = true;
                    Physics.RaycastHit tempHit = hit;
                    while (Vector3.Distance(minPoint, tempHit.point) < Vector3.Distance(minPoint, gameObject.Transform.Position + direction) && hit != null)
                    {

                        if (Physics.Raycast(tempHit.point + direction, direction, out hit))
                        {
                            tempHit = hit;
                        }

                    }
                    if (hit != null)
                    {
                        test = new GameObject(hit.point, false);
                        test.physicLayer = Layer.Marker;
                        test.AddNewComponent<MeshRenderer>();

                        foreach (GameObject item in SceneManager.Instance.GetGameObjectsFromCurrentScene())
                        {
                            if(item.physicLayer != Layer.Enemy) continue;
                            item.GetComponent<EnemyAI>().markerPosition = test.Transform.Position;
                        }

                        Effect e = SceneManager.Instance.Content.Load<Effect>("Shaders/PhongBlinnShader");
                        test.GetComponent<MeshRenderer>().Material = new DefaultMaterial(e);
                        test.GetComponent<MeshRenderer>().Load(SceneManager.Instance.Content,ContentModels.Instance.ball, 0.05f);


                        //Debug.WriteLine("Hit!" + " " + hit.collider.gameObject + " " + hit.distance);
                    }
                }
                isPressed = true;
            }

            if (ms.RightButton == ButtonState.Released)
            {
                isPressed = false;
            }

            #endregion

            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.D3) && gameObject.GetComponent<PlayerBullets>().aggresiveBullet)
            {
                currentBulletLoaded = PlayerBullets.Bullets.Agressive;
            }
            if (keyState.IsKeyDown(Keys.D2) && gameObject.GetComponent<PlayerBullets>().transmitterBullet)
            {
                currentBulletLoaded = PlayerBullets.Bullets.Transmitter;
            }
            if (keyState.IsKeyDown(Keys.D1) && gameObject.GetComponent<PlayerBullets>().paralysisBullet)
            {
                currentBulletLoaded = PlayerBullets.Bullets.Paralysis;
            }
            if (ms.ScrollWheelValue > previousScrollValue)
            {

                if (currentBulletLoaded != null)
                {
                    if ((int) currentBulletLoaded < Enum.GetNames(typeof(PlayerBullets.Bullets)).Length -1)
                    {
                        currentBulletLoaded += 1;
                    }
                    else
                    {
                        currentBulletLoaded = (PlayerBullets.Bullets)Enum.GetValues(typeof(PlayerBullets.Bullets)).GetValue(0);
                    }
                }
            }
            if (ms.ScrollWheelValue < previousScrollValue)
            {

                if (currentBulletLoaded != null)
                {
                    if ((int)currentBulletLoaded > 0)
                    {
                        currentBulletLoaded -= 1;
                    }
                    else
                    {
                        currentBulletLoaded = (PlayerBullets.Bullets)Enum.GetValues(typeof(PlayerBullets.Bullets)).GetValue(Enum.GetValues(typeof(PlayerBullets.Bullets)).Length - 1);
                    }
                }
            }

            previousScrollValue = ms.ScrollWheelValue;
            //base.Update();
        }

        public override void Draw(Camera cam)
        {
            test?.Draw(cam);
            base.Draw(cam);
        }

        public PlayerBullets.Bullets? GetLoadedBullet()
        {
            return currentBulletLoaded;
        }

        public void SetBulletLoad(PlayerBullets.Bullets? bullet)
        {
            currentBulletLoaded = bullet;
        }
    }
}

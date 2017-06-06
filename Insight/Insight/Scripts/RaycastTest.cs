using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;
using Insight.Scenes;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using Insight.Engine.Components;
using Insight.Materials;
using Microsoft.Xna.Framework.Graphics;

namespace Insight.Scripts
{
    class RaycastTest : BaseScript
    {
        Physics.RaycastHit hit;

        bool isPressed = false;

        private GameObject test;



        private PlayerBullets.Bullets? currentBulletLoaded;

        public RaycastTest(GameObject gameObject) : base(gameObject)
        {
            currentBulletLoaded = null;
        }

        public override void Update()
        {
            MouseState ms = Mouse.GetState();

            #region LeftButton
            if (ms.LeftButton == ButtonState.Pressed && !isPressed && currentBulletLoaded != null)
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
                        //test = new GameObject(hit.point, false);
                        //test.AddNewComponent<MeshRenderer>();

                        //Effect e = SceneManager.Instance.Content.Load<Effect>("Shaders/PhongBlinnShader");
                        //test.GetComponent<MeshRenderer>().Material = new DefaultMaterial(e);
                        //test.GetComponent<MeshRenderer>().Load(SceneManager.Instance.Content);


                        //Debug.WriteLine("Hit!" + " " + hit.collider.gameObject + " " + hit.distance);

                        if (hit.collider.gameObject.physicLayer == Layer.Enemy)
                        {
                            hit.collider.gameObject.GetComponent<EnemyAI>().Hit(100);
                        }
                    }
                }
                switch (currentBulletLoaded)
                {
                    case PlayerBullets.Bullets.Agressive:
                        gameObject.GetComponent<PlayerBullets>().aggresiveBullet = false;
                        if (gameObject.GetComponent<PlayerBullets>().transmitterBullet)
                        {
                            currentBulletLoaded = PlayerBullets.Bullets.Transmitter;
                        }
                        break;
                    case PlayerBullets.Bullets.Transmitter:
                        gameObject.GetComponent<PlayerBullets>().transmitterBullet = false;
                        if (gameObject.GetComponent<PlayerBullets>().aggresiveBullet)
                        {
                            currentBulletLoaded = PlayerBullets.Bullets.Agressive;
                        }
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
                        test.AddNewComponent<MeshRenderer>();

                        Effect e = SceneManager.Instance.Content.Load<Effect>("Shaders/PhongBlinnShader");
                        test.GetComponent<MeshRenderer>().Material = new DefaultMaterial(e);
                        test.GetComponent<MeshRenderer>().Load(SceneManager.Instance.Content);


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
            if (keyState.IsKeyDown(Keys.D1) && gameObject.GetComponent<PlayerBullets>().aggresiveBullet)
            {
                currentBulletLoaded = PlayerBullets.Bullets.Agressive;
            }
            if (keyState.IsKeyDown(Keys.D2) && gameObject.GetComponent<PlayerBullets>().aggresiveBullet)
            {
                currentBulletLoaded = PlayerBullets.Bullets.Transmitter;
            }
            //base.Update();
        }

        public override void Draw(Camera cam)
        {
            test?.Draw(cam);
            base.Draw(cam);
        }
    }
}

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

        public RaycastTest(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Update()
        {
            MouseState ms = Mouse.GetState();    

            if (ms.LeftButton == ButtonState.Pressed && !isPressed)
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
                    test = new GameObject(hit.point, false);
                    test.AddNewComponent<MeshRenderer>();

                    Effect e = SceneManager.Instance.Content.Load<Effect>("Shaders/PhongBlinnShader");
                    test.GetComponent<MeshRenderer>().Material = new DefaultMaterial(e);
                    test.GetComponent<MeshRenderer>().Load(SceneManager.Instance.Content);

                    Debug.WriteLine("Hit!" + " " + hit.collider.gameObject + " " + hit.distance);
                }
                isPressed = true;
            }

            if (ms.LeftButton == ButtonState.Released)
                isPressed = false;
            //base.Update();
        }

        public override void Draw(Camera cam)
        {
            test?.Draw(cam);
            base.Draw(cam);
        }
    }
}

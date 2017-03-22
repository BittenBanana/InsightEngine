using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Insight.Engine;
using Insight.Scripts;
using Insight.Engine.Components;

namespace Insight.Scenes
{
    class MainScene : GameScene
    {
        List<GameObject> gameObjects;
        GameObject gameObject;
        GameObject gameObject2;
        Camera mainCam;

        public static Matrix projection { get; private set; }

        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            gameObjects = new List<GameObject>();
            gameObject = new GameObject();
            gameObject.AddNewComponent<MeshRenderer>();         
            gameObject2 = new GameObject(new Vector3(20, 0, 20));
            gameObject2.AddNewComponent<MeshRenderer>();
            
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), graphics.GraphicsDevice.Viewport.AspectRatio, .1f, 1000f);
        }

        public override void LoadContent()
        {
            base.LoadContent();

            gameObject.LoadContent(content);
            gameObject2.LoadContent(content);
            gameObject.AddNewComponent<BoxCollider>();
            gameObject2.AddNewComponent<BoxCollider>();
            gameObject.AddNewComponent<Camera>();

            mainCam = gameObject.GetComponent<Camera>();
            gameObject.AddNewComponent<BoxController>();

            gameObject.AddNewComponent<CameraFollowBox>();

            gameObjects.Add(gameObject);
            gameObjects.Add(gameObject2);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject go in gameObjects)
            {
                go.Update();
            }
            base.Update(gameTime);
        }
        public override void Draw()
        {
            foreach (GameObject go in gameObjects)
            {
                go.Draw(mainCam);
            }

            gameObject.GetComponent<BoxCollider>().Draw(projection, graphics, gameObject.GetComponent<Camera>().view);
            gameObject2.GetComponent<BoxCollider>().Draw(projection, graphics, mainCam.view);

            base.Draw();
        }
    }
}

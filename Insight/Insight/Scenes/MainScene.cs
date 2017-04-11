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
        private static List<GameObject> gameObjects;
        GameObject gameObject;
        GameObject gameObject2;
        GameObject gameObject3;
        GameObject gameObject4;
        GameObject box;
        Camera mainCam;
        ColliderManager colliderManager;

        public static Matrix projection { get; private set; }

        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            gameObjects = new List<GameObject>();
            gameObject = new GameObject(true);
            gameObject.AddNewComponent<MeshRenderer>();
            gameObject2 = new GameObject(new Vector3(0, -20, 0), false);
            gameObject2.AddNewComponent<MeshRenderer>();
            gameObject3 = new GameObject(new Vector3(0, 0, 5), true);
            gameObject3.AddNewComponent<MeshRenderer>();
            gameObject4 = new GameObject(new Vector3(0, -10, 50), false);
            gameObject4.AddNewComponent<MeshRenderer>();
            box = new GameObject(new Vector3(0, -10, 20), false);
            box.AddNewComponent<MeshRenderer>();

            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), graphics.GraphicsDevice.Viewport.AspectRatio, .1f, 1000f);
        }

        public override void LoadContent()
        {
            base.LoadContent();

            gameObject.LoadContent(content);
            gameObject2.LoadContent(content);
            gameObject2.GetComponent<MeshRenderer>().Load(content, "ground", 0.1f);
            gameObject3.LoadContent(content);
            box.LoadContent(content);
            gameObject3.GetComponent<MeshRenderer>().Load(content, "viking", 0.1f);
            gameObject4.LoadContent(content);
            gameObject4.GetComponent<MeshRenderer>().Load(content, "wall", 0.1f);
            box.GetComponent<MeshRenderer>().Load(content, "GameObject/boxMat", 2f);
            box.AddNewComponent<BoxCollider>();
            box.AddNewComponent<Rigidbody>();
            box.GetComponent<Rigidbody>().useGravity = false;
            gameObject.AddNewComponent<BoxController>();
            gameObject.AddNewComponent<SphereCollider>();
            gameObject.AddNewComponent<Rigidbody>();
            gameObject2.AddNewComponent<BoxCollider>();
            gameObject3.AddNewComponent<SphereCollider>();
            gameObject4.AddNewComponent<BoxCollider>();
            gameObject.AddNewComponent<Camera>();
            gameObject2.AddNewComponent<Rigidbody>();
            gameObject3.AddNewComponent<Rigidbody>();
            gameObject4.AddNewComponent<Rigidbody>();
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject2.GetComponent<Rigidbody>().useGravity = false;
            gameObject4.GetComponent<Rigidbody>().useGravity = false;
            gameObject2.physicLayer = Layer.Ground;
            gameObject3.physicLayer = Layer.IgnoreRaycast;
            gameObject.physicLayer = Layer.Player;
            gameObject.AddNewComponent<RaycastTest>();
            box.GetComponent<BoxCollider>().IsTrigger = true;

            mainCam = gameObject.GetComponent<Camera>();

            gameObject.AddNewComponent<CameraFollowBox>();
            //gameObject2.AddNewComponent<BoxRotation>();
            gameObjects.Add(gameObject);
            gameObjects.Add(gameObject2);
            gameObjects.Add(gameObject3);
            gameObjects.Add(gameObject4);
            gameObjects.Add(box);
            colliderManager = new ColliderManager(gameObjects);
            colliderManager.ObjectColided += gameObject.OnObjectColided;
            colliderManager.ObjectColided += gameObject3.OnObjectColided;

            gameObject.EnterTriggerActivated += gameObject.GetComponent<BoxController>().OnTriggerEnter;
            gameObject.StayTriggerActivated += gameObject.GetComponent<BoxController>().OnTriggerStay;
            gameObject.ExitTriggerActivated += gameObject.GetComponent<BoxController>().OnTriggerExit;
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
            colliderManager.Update();
            base.Update(gameTime);
        }
        public override void Draw()
        {
            foreach (GameObject go in gameObjects)
            {
                go.Draw(mainCam);
            }

            gameObject.GetComponent<SphereCollider>().DrawSphereSpikes(gameObject.GetComponent<SphereCollider>().GetPreciseBoundingSpheres()[0], graphics.GraphicsDevice, gameObject.GetComponent<MeshRenderer>().GetMatrix(), gameObject.GetComponent<Camera>().view, projection);
            gameObject2.GetComponent<BoxCollider>().Draw(projection, graphics, mainCam.view);
            //gameObject2.GetComponent<BoxCollider>().DrawSphereSpikes(gameObject2.GetComponent<BoxCollider>().GetCompleteBoundingSphere(), graphics.GraphicsDevice, gameObject2.GetComponent<MeshRenderer>().GetMatrix(), mainCam.view, projection);

            base.Draw();
        }

        public static List<GameObject> GetGameObjects()
        {
            return gameObjects;
        }
    }
}

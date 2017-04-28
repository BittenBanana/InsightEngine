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
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;

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
        GameObject animationTest;
        Camera mainCam;
        ColliderManager colliderManager;
        AudioManager audioManager;


        public static Matrix projection { get; private set; }

        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            gameObjects = new List<GameObject>();
            gameObject = new GameObject(true);
            gameObject.AddNewComponent<MeshRenderer>();
            gameObject2 = new GameObject(new Vector3(0, -13, 0), false);
            gameObject2.AddNewComponent<MeshRenderer>();
            gameObject3 = new GameObject(new Vector3(0, 0, 10), false);
            gameObject3.AddNewComponent<MeshRenderer>();
            gameObject4 = new GameObject(new Vector3(0, -3, 50), false);
            gameObject4.AddNewComponent<MeshRenderer>();
            box = new GameObject(new Vector3(0, -1, 20), false);
            box.AddNewComponent<MeshRenderer>();
            
            

            animationTest = new GameObject(new Vector3(0, -5, 40), true);
            animationTest.AddNewComponent<AnimationRender>();

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
            gameObject3.AddNewComponent<BoxCollider>();
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
            gameObject3.Transform.Rotation.Y = 50f;
            animationTest.LoadContent(content);

            colliderManager = new ColliderManager(gameObjects);
            colliderManager.ObjectColided += gameObject.OnObjectColided;
            colliderManager.ObjectColided += gameObject3.OnObjectColided;

            audioManager = new AudioManager(gameObject, content);
            audioManager.AddSoundEffectWithEmitter("tomek2", gameObject3);
            audioManager.AddSoundEffectWithEmitter("sandman", gameObject4);
            audioManager.SetSoundEffectLooped(0, true);
            audioManager.SetSoundEffectLooped(1, true);
            audioManager.PlaySoundEffect(0);
            audioManager.PlaySoundEffect(1);
            audioManager.AddSong("dj");
            audioManager.PlaySong(0);
            audioManager.StopCurrentSong();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            foreach (GameObject go in gameObjects)
            {
                go.Update();
            }
            colliderManager.Update();
            audioManager.Update();
            animationTest.Update();
        }
        public override void Draw()
        {
            foreach (GameObject go in gameObjects)
            {
                go.Draw(mainCam);
            }

            animationTest.GetComponent<AnimationRender>().Draw(mainCam);
            //gameObject.GetComponent<SphereCollider>().DrawSphereSpikes(gameObject.GetComponent<SphereCollider>().GetPreciseBoundingSpheres()[0], graphics.GraphicsDevice, gameObject.GetComponent<MeshRenderer>().GetMatrix(), gameObject.GetComponent<Camera>().view, projection);
            //gameObject.GetComponent<BoxCollider>().Draw(projection, graphics, gameObject.GetComponent<Camera>().view);
            gameObject4.GetComponent<BoxCollider>().Draw(projection, graphics, mainCam.view);
            //gameObject3.GetComponent<BoxCollider>().DrawSphereSpikes(gameObject3.GetComponent<BoxCollider>().GetCompleteBoundingSphere(), graphics.GraphicsDevice, gameObject3.GetComponent<MeshRenderer>().GetMatrix(), mainCam.view, projection);
            //gameObject2.GetComponent<BoxCollider>().Draw(projection, graphics, mainCam.view);
            //gameObject2.GetComponent<BoxCollider>().DrawSphereSpikes(gameObject2.GetComponent<BoxCollider>().GetCompleteBoundingSphere(), graphics.GraphicsDevice, gameObject2.GetComponent<MeshRenderer>().GetMatrix(), mainCam.view, projection);

            base.Draw();
        }

        public static List<GameObject> GetGameObjects()
        {
            return gameObjects;
        }
    }
}

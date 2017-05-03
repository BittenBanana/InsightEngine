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
        Texture2D rocket;
        Texture2D piggyBank;
        Texture2D screen;
        Texture2D blood;
        SpriteBatch spriteBatch;
        float bloodLevel;


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
            bloodLevel = 0;
            
            

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
            //audioManager.PlaySoundEffect(0);
            //audioManager.PlaySoundEffect(1);
            audioManager.AddSong("dj");
            audioManager.PlaySong(0);
            audioManager.StopCurrentSong();
            rocket = content.Load<Texture2D>("rakieta");
            piggyBank = content.Load<Texture2D>("skarbonka");
            screen = content.Load<Texture2D>("monitor");
            blood = content.Load<Texture2D>("blood");
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
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

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.LeftControl))
            {
                bloodLevel += 0.09f;
            }
        }
        public override void Draw()
        {
            graphics.GraphicsDevice.Clear(Color.LightBlue);
            

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


            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend);
            spriteBatch.Draw(rocket, new Vector2(30, 410), Color.White);
            spriteBatch.Draw(piggyBank, new Vector2(90, 412), Color.White);
            spriteBatch.Draw(screen, new Vector2(150, 415), Color.White);
            spriteBatch.Draw(blood, new Vector2(0, 0), Color.White * bloodLevel);
            spriteBatch.End();

            graphics.GraphicsDevice.BlendState = BlendState.Opaque;
            graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            graphics.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;

            base.Draw();
        }

        public static List<GameObject> GetGameObjects()
        {
            return gameObjects;
        }
    }
}

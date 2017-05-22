using Insight.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Insight.Engine.Components;
using Microsoft.Xna.Framework.Graphics;
using Insight.Materials;
using Insight.Scripts;
using Insight.Engine.Prefabs;
using System.Diagnostics;

namespace Insight.Scenes
{
    class DemoScene : GameScene
    {
        static String floorPrefab = "floor5x5";
        //GameObject floor1;
        TestPrefab testPrefab;
        Corridor corridor;
        CornerLeft cornerLeft;
        CorridorRotated corridorRotated;
        Corridor3Way corridor3Way;
        GameObject player;
        Camera mainCam;
        Material defaultMaterial;
        GameObject directionalLight;
        ColliderManager colliderManager;

        public override void Initialize(GraphicsDeviceManager graphicsDevice)
        {
            base.Initialize(graphicsDevice);

            player = new GameObject(new Vector3(2, 1, 2), true);
            player.AddNewComponent<MeshRenderer>();
            player.physicLayer = Layer.Player;
            
            //player.AddNewComponent<Rigidbody>();

            //floor1 = new GameObject(new Vector3(0, 0, 0), false);
            //floor1.AddNewComponent<MeshRenderer>();
            //testPrefab = new TestPrefab();
            //testPrefab.Initialize(new Vector3(0, 0, 2));

            corridor = new Corridor();
            corridor.Initialize(new Vector3(0));

            cornerLeft = new CornerLeft();
            cornerLeft.Initialize(new Vector3(0, 0, 5));

            //corridorRotated = new CorridorRotated();
            //corridorRotated.Initialize(new Vector3(6, 0, 6));

            corridor3Way = new Corridor3Way();
            corridor3Way.Initialize(new Vector3(6, 0, 6));

            directionalLight = new GameObject(new Vector3(-5, 5, 0), false);
            directionalLight.AddNewComponent<Light>();
            directionalLight.GetComponent<Light>().Direction = new Vector3(3, -5, 0);
            directionalLight.GetComponent<Light>().Color = Color.White;

            gameObjects.Add(player);
            gameObjects.Add(directionalLight);

            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), graphics.GraphicsDevice.Viewport.AspectRatio, .1f, 1000f);
            colliderManager = new ColliderManager(gameObjects);
        }

        public override void LoadContent()
        {
            base.LoadContent();
            #region Effects 

            Effect effect = content.Load<Effect>("Shaders/PhongBlinnShader");
            defaultMaterial = new DefaultMaterial(effect);
            ((DefaultMaterial)defaultMaterial).LightDirection = directionalLight.GetComponent<Light>().Direction;
            ((DefaultMaterial)defaultMaterial).LightColor = directionalLight.GetComponent<Light>().Color.ToVector3();
            ((DefaultMaterial)defaultMaterial).SpecularColor = directionalLight.GetComponent<Light>().Color.ToVector3();
            #endregion

            foreach (var o in gameObjects)
            {
                if (o.GetComponent<MeshRenderer>() != null)
                    o.GetComponent<MeshRenderer>().Material = defaultMaterial;
            }
            foreach (var item in gameObjects)
            {
                item.LoadContent(content);
            }

            
            //floor1.GetComponent<MeshRenderer>().Load(content, "floor5x5", 1.0f);
            //testPrefab.LoadContent(content);
            
            player.GetComponent<MeshRenderer>().Load(content, "Models/Konrads/Character/superBoxHero", 1f);
            player.AddNewComponent<Camera>();
            player.AddNewComponent<BoxController>();
            //player.AddNewComponent<ThirdPersonCamera>();
            player.AddNewComponent<CameraFollowBox>();
            mainCam = player.GetComponent<Camera>();
            player.AddNewComponent<SphereCollider>();
            corridor.LoadContent(content);
            cornerLeft.LoadContent(content);
            //corridorRotated.LoadContent(content);
            corridor3Way.LoadContent(content);
            colliderManager.ObjectColided += player.OnObjectColided;
            Debug.WriteLine(gameObjects.Count + "=============================");
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
        }

        public override void Draw()
        {
            graphics.GraphicsDevice.Clear(Color.LightBlue);
            foreach (GameObject go in gameObjects)
            {
                go.Draw(mainCam);
            }
            //gameObjects[5].GetComponent<BoxCollider>().Draw(projection, graphics, mainCam.view);
            //for (int i = 0; i < player.GetComponent<SphereCollider>().GetPreciseBoundingSpheres().Length; i++)
            //{
            //    player.GetComponent<SphereCollider>().DrawSphereSpikes(player.GetComponent<SphereCollider>().GetPreciseBoundingSpheres()[i], graphics.GraphicsDevice, player.GetComponent<MeshRenderer>().GetMatrix(), player.GetComponent<Camera>().view, projection);
            //}

            graphics.GraphicsDevice.BlendState = BlendState.Opaque;
            graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            graphics.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
        }
    }
}

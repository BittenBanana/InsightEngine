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
        Corridor corridor2;
        Corridor corridor3;
        Corridor corridor4;
        CornerLeft cornerLeft;
        CorridorRotated corridorRotated;
        CorridorRotated corridorRotated2;
        CorridorRotated corridorRotated3;
        CorridorRotated corridorRotated4;
        Corridor3Way corridor3Way;
        Column column;
        ColumnRotated columnRotated;
        GameObject player;
        Camera mainCam;
        Material defaultMaterial;
        GameObject directionalLight;
        ColliderManager colliderManager;

        GameObject enemy;

        private GameObject cameraPivot;

        public override void Initialize(GraphicsDeviceManager graphicsDevice)
        {
            base.Initialize(graphicsDevice);

            

            player = new GameObject(new Vector3(2, 1, 2), true);
            player.AddNewComponent<MeshRenderer>();
            player.physicLayer = Layer.Player;

            enemy = new GameObject(new Vector3(17, 0, 0), true);
            enemy.AddNewComponent<MeshRenderer>();
            
            //player.AddNewComponent<Rigidbody>();

            cameraPivot = new GameObject(player.Transform.Position, false);

            //floor1 = new GameObject(new Vector3(0, 0, 0), false);
            //floor1.AddNewComponent<MeshRenderer>();
            //testPrefab = new TestPrefab();
            //testPrefab.Initialize(new Vector3(0, 0, 2));

            corridor = new Corridor();
            corridor.Initialize(new Vector3(0));

            corridor2 = new Corridor();
            corridor2.Initialize(new Vector3(0, 0, 5));

            cornerLeft = new CornerLeft();
            cornerLeft.Initialize(new Vector3(0, 0, 10));

            corridorRotated = new CorridorRotated();
            corridorRotated.Initialize(new Vector3(6, 0, 11));

            corridorRotated2 = new CorridorRotated();
            corridorRotated2.Initialize(new Vector3(11, 0, 11));

            corridorRotated3 = new CorridorRotated();
            corridorRotated3.Initialize(new Vector3(21, 0, 11));

            corridorRotated4 = new CorridorRotated();
            corridorRotated4.Initialize(new Vector3(26, 0, 11));

            corridor3Way = new Corridor3Way();
            corridor3Way.Initialize(new Vector3(16, 0, 11));

            corridor3 = new Corridor();
            corridor3.Initialize(new Vector3(16, 0, 1));

            corridor4 = new Corridor();
            corridor4.Initialize(new Vector3(16, 0, 6));

            column = new Column();
            column.Initialize(new Vector3(16, 0, 11));

            columnRotated = new ColumnRotated();
            columnRotated.Initialize(new Vector3(21, 0, 11));

            directionalLight = new GameObject(new Vector3(-5, 5, 0), false);
            directionalLight.AddNewComponent<Light>();
            directionalLight.GetComponent<Light>().Direction = new Vector3(3, -5, 0);
            directionalLight.GetComponent<Light>().Color = Color.White;

            gameObjects.Add(player);
            gameObjects.Add(directionalLight);
            gameObjects.Add(cameraPivot);
            gameObjects.Add(enemy);

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
            enemy.LoadContent(content, "Models/Konrads/Character/superBoxHero", 1f);
            cameraPivot.AddNewComponent<Camera>();
            cameraPivot.AddNewComponent<CameraPivotFollow>();
            cameraPivot.GetComponent<CameraPivotFollow>().player = player;
            cameraPivot.AddNewComponent<RaycastTest>();

            player.AddNewComponent<BoxController>();
            cameraPivot.AddNewComponent<CameraFollowBox>();
            cameraPivot.GetComponent<CameraFollowBox>().player = player;
            mainCam = cameraPivot.GetComponent<Camera>();
            player.AddNewComponent<SphereCollider>();
            enemy.AddNewComponent<BasicAI>();
            corridor.LoadContent(content);
            corridor2.LoadContent(content);
            corridor3.LoadContent(content);
            corridor4.LoadContent(content);
            cornerLeft.LoadContent(content);
            corridorRotated.LoadContent(content);
            corridorRotated2.LoadContent(content);
            corridorRotated3.LoadContent(content);
            corridorRotated4.LoadContent(content);
            corridor3Way.LoadContent(content);
            column.LoadContent(content);
            columnRotated.LoadContent(content);
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

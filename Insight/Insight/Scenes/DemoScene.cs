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
using Microsoft.Xna.Framework.Input;

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
        Corridor corridor5;
        CornerLeft cornerLeft;
        CornerRightRotated cornerRight;
        CorridorRotated corridorRotated;
        CorridorRotated corridorRotated2;
        CorridorRotated corridorRotated3;
        CorridorRotated corridorRotated4;
        Corridor3Way corridor3Way;
        Column column;
        ColumnRotated columnRotated;
        Door door;
        RoomFloor roomFloor;
        RoomFloor roomFloor2;
        RoomFloor roomFloor3;
        RoomFloor roomFloor4;
        RoomFloor roomFloor5;
        RoomFloor roomFloor6;
        RoomFloor roomFloor7;
        RoomFloor roomFloor8;
        RoomFloor roomFloor9;
        RoomFloorSmallerRotated roomFloor10;
        GameObject player;
        Camera mainCam;
        Material defaultMaterial;
        GameObject directionalLight;
        ColliderManager colliderManager;

        GameObject enemy;

        GameObject bulletDispenser;
        GameObject dispenserTrigger;

        int _total_frames = 0;
        float _elapsed_time = 0.0f;
        int _fps = 0;

        private GameObject cameraPivot;

        public override void Initialize(GraphicsDeviceManager graphicsDevice)
        {
            base.Initialize(graphicsDevice);

            

            player = new GameObject(new Vector3(2, 1, 2), true);
            player.AddNewComponent<MeshRenderer>();
            player.physicLayer = Layer.Player;

            enemy = new GameObject(new Vector3(17, 0, 0), false);
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

            cornerRight = new CornerRightRotated();
            cornerRight.Initialize(new Vector3(31, 0, 11));

            corridor3Way = new Corridor3Way();
            corridor3Way.Initialize(new Vector3(16, 0, 11));

            corridor3 = new Corridor();
            corridor3.Initialize(new Vector3(16, 0, 1));

            corridor4 = new Corridor();
            corridor4.Initialize(new Vector3(16, 0, 6));

            door = new Door();
            door.Initialize(new Vector3(19.17f, 0, 1));         

            column = new Column();
            column.Initialize(new Vector3(16, 0, 11));

            columnRotated = new ColumnRotated();
            columnRotated.Initialize(new Vector3(21, 0, 11));

            corridor5 = new Corridor();
            corridor5.Initialize(new Vector3(32, 0, 17));

            roomFloor = new RoomFloor();
            roomFloor.Initialize(new Vector3(32, 0, 22));

            roomFloor2 = new RoomFloor();
            roomFloor2.Initialize(new Vector3(32, 0, 27));

            roomFloor3 = new RoomFloor();
            roomFloor3.Initialize(new Vector3(32, 0, 32));

            roomFloor4 = new RoomFloor();
            roomFloor4.Initialize(new Vector3(27, 0, 22));

            roomFloor5 = new RoomFloor();
            roomFloor5.Initialize(new Vector3(27, 0, 27));

            roomFloor6 = new RoomFloor();
            roomFloor6.Initialize(new Vector3(27, 0, 32));

            roomFloor7 = new RoomFloor();
            roomFloor7.Initialize(new Vector3(37, 0, 22));

            roomFloor8 = new RoomFloor();
            roomFloor8.Initialize(new Vector3(37, 0, 27));

            roomFloor9 = new RoomFloor();
            roomFloor9.Initialize(new Vector3(37, 0, 32));

            roomFloor10 = new RoomFloorSmallerRotated();
            roomFloor10.Initialize(new Vector3(42, 0, 27));

            directionalLight = new GameObject(new Vector3(-5, 5, 0), false);
            directionalLight.AddNewComponent<Light>();
            directionalLight.GetComponent<Light>().Direction = new Vector3(3, -5, 0);
            directionalLight.GetComponent<Light>().Color = Color.White;
            
            bulletDispenser = new GameObject(new Vector3(20, 0, -5), false);
            bulletDispenser.AddNewComponent<MeshRenderer>();
            dispenserTrigger = new GameObject(new Vector3(22, 0, -5), false);
            dispenserTrigger.AddNewComponent<MeshRenderer>();

            gameObjects.Add(player);
            gameObjects.Add(directionalLight);
            gameObjects.Add(cameraPivot);
            gameObjects.Add(enemy);
            gameObjects.Add(bulletDispenser);
            gameObjects.Add(dispenserTrigger);

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
            enemy.AddNewComponent<SphereCollider>();
            corridor.LoadContent(content);
            corridor2.LoadContent(content);
            corridor3.LoadContent(content);
            corridor4.LoadContent(content);
            corridor5.LoadContent(content);
            cornerLeft.LoadContent(content);
            cornerRight.LoadContent(content);
            corridorRotated.LoadContent(content);
            corridorRotated2.LoadContent(content);
            corridorRotated3.LoadContent(content);
            corridorRotated4.LoadContent(content);
            corridor3Way.LoadContent(content);
            column.LoadContent(content);
            columnRotated.LoadContent(content);
            door.LoadContent(content);
            roomFloor.LoadContent(content);
            roomFloor2.LoadContent(content);
            roomFloor3.LoadContent(content);
            roomFloor4.LoadContent(content);
            roomFloor5.LoadContent(content);
            roomFloor6.LoadContent(content);
            roomFloor7.LoadContent(content);
            roomFloor8.LoadContent(content);
            roomFloor9.LoadContent(content);
            roomFloor10.LoadContent(content);
            colliderManager.ObjectColided += player.OnObjectColided;

            bulletDispenser.GetComponent<MeshRenderer>().Load(content, "Models/bulletdispenser", 1f);
            dispenserTrigger.GetComponent<MeshRenderer>().Load(content, "Models/dispensertrigger", 1f);

            bulletDispenser.AddNewComponent<BoxCollider>();
            dispenserTrigger.AddNewComponent<BoxCollider>();
            dispenserTrigger.GetComponent<BoxCollider>().IsTrigger = true;
            dispenserTrigger.GetComponent<MeshRenderer>().IsVisible = false;
            dispenserTrigger.physicLayer = Layer.DispenserTrigger;


            ui = new UserInterface(player, graphics.GraphicsDevice, content);
            ui.AddSprite("Sprites/rakieta", "rakieta", new Vector2(30, 410), Color.White, 1);
            ui.AddSprite("Sprites/skarbonka", "skarbonka", new Vector2(90, 412), Color.White, 1);
            ui.AddSprite("Sprites/monitor", "monitor", new Vector2(150, 415), Color.White, 1);
            ui.AddSprite("Sprites/blood", "blood", new Vector2(0, 0), Color.White, 0);
            ui.AddSprite("Sprites/rakieta", "bulletRakieta", new Vector2(380, 30), Color.White, 0);
            ui.AddText("Fonts/gamefont", "generalFont", string.Format("FPS={0}", _fps), new Vector2(10, 20), Color.White, 1);
            ui.AddText("Fonts/gamefont", "hint", "Press E to open doors", new Vector2(350, 200), Color.White, 0);
            ui.AddText("Fonts/gamefont", "dispenserHint", "Press E to take the bullet", new Vector2(320, 80), Color.White, 0);


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

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.LeftControl))
            {
                ui.ChangeSpriteOpacity("blood", 0.05f);
            }

            ui.ChangeText("generalFont", string.Format("FPS={0}", _fps));

            // Update
            _elapsed_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // 1 Second has passed
            if (_elapsed_time >= 1000.0f)
            {
                _fps = _total_frames;
                _total_frames = 0;
                _elapsed_time = 0;
            }

            if (Mouse.GetState().Position.X >= graphics.GraphicsDevice.Viewport.Width)
            {
                Mouse.SetPosition(0,Mouse.GetState().Position.Y);
            }

            else if (Mouse.GetState().Position.X <= 0)
            {
                Mouse.SetPosition(graphics.GraphicsDevice.Viewport.Width, Mouse.GetState().Position.Y);
            }

            //if (Mouse.GetState().Position.Y <= graphics.GraphicsDevice.Viewport.Height)
            //{
            //    Mouse.SetPosition(Mouse.GetState().Position.X, 0);
            //}

            //else if (Mouse.GetState().Position.X >= 0)
            //{
            //    Mouse.SetPosition(Mouse.GetState().Position.X, graphics.GraphicsDevice.Viewport.Height);
            //}
        }

        public override void Draw()
        {
            graphics.GraphicsDevice.Clear(Color.LightBlue);
            foreach (GameObject go in gameObjects)
            {
                go.Draw(mainCam);
            }
            ui.Draw();
            //gameObjects[5].GetComponent<BoxCollider>().Draw(projection, graphics, mainCam.view);
            //for (int i = 0; i < player.GetComponent<SphereCollider>().GetPreciseBoundingSpheres().Length; i++)
            //{
            //    player.GetComponent<SphereCollider>().DrawSphereSpikes(player.GetComponent<SphereCollider>().GetPreciseBoundingSpheres()[i], graphics.GraphicsDevice, player.GetComponent<MeshRenderer>().GetMatrix(), player.GetComponent<Camera>().view, projection);
            //}
            _total_frames++;
            graphics.GraphicsDevice.BlendState = BlendState.Opaque;
            graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            graphics.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
        }
    }
}

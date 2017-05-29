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
        Corridor corridor6;
        Corridor corridor7;
        Corridor corridor8;
        Corridor corridor9;
        CornerLeft cornerLeft;
        CornerLeft cornerLeft2;
        CornerRightRotated cornerRight;
        CornerRightRotated cornerRight2;
        CornerRightRotated cornerRight3;
        CorridorRotated corridorRotated;
        CorridorRotated corridorRotated2;
        CorridorRotated corridorRotated3;
        CorridorRotated corridorRotated4;
        CorridorRotated corridorRotated5;
        Corridor3Way corridor3Way;
        Corridor3Way corridor3Way2;
        Column column;
        ColumnRotated columnRotated;
        Column column2;
        ColumnRotated columnRotated2;
        Door door;
        Door door2;
        Door door3;
        Door door4;
        Door door5;
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
        RoomFloor roomFloor11;
        RoomFloor roomFloor12;
        RoomFloor roomFloor13;
        RoomFloor roomFloor14;
        RoomFloor roomFloor15;
        RoomFloor roomFloor16;
        RoomFloor roomFloor17;
        RoomFloor roomFloor18;
        RoomFloor roomFloor19;
        RoomFloor roomFloor20;
        RoomFloor roomFloor21;
        RoomFloor roomFloor22;
        RoomFloor roomFloor23;
        RoomFloor roomFloor24;
        RoomFloorSmallerRotated roomFloor25;
        Wall wall;
        Wall wall2;
        WallRotated wall3;
        WallRotated wall4;
        WallRotated wall5;
        WallSmaller wall6;
        WallVisible wall7;
        WallVisible wall8;
        WallVisible wall9;
        WallVisible wall10;
        WallVisible wall11;
        WallSmaller wall12;
        Wall wall13;
        WallVisible wall14;
        WallVisible wall15;
        WallVisible wall16;
        WallVisible wall17;
        Wall wall18;
        Wall wall19;
        WallVisible wall20;
        WallShorter wall21;
        WallShorter wall22;
        Stairs stairs;
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
            enemy.AddNewComponent<AnimationRender>();
            
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
            corridorRotated.Initialize(new Vector3(6, 0, 16), new Vector3(0, 1.571f, 0));

            corridorRotated2 = new CorridorRotated();
            corridorRotated2.Initialize(new Vector3(11, 0, 16), new Vector3(0, 1.571f, 0));

            corridorRotated3 = new CorridorRotated();
            corridorRotated3.Initialize(new Vector3(21, 0, 16), new Vector3(0, 1.571f, 0));

            corridorRotated4 = new CorridorRotated();
            corridorRotated4.Initialize(new Vector3(26, 0, 16), new Vector3(0, 1.571f, 0));

            cornerRight = new CornerRightRotated();
            cornerRight.Initialize(new Vector3(37, 0, 17), new Vector3(0, 3.142f, 0));

            corridor3Way = new Corridor3Way();
            corridor3Way.Initialize(new Vector3(16, 0, 16), new Vector3(0, 1.571f, 0));

            corridor3 = new Corridor();
            corridor3.Initialize(new Vector3(16, 0, 1));

            corridor4 = new Corridor();
            corridor4.Initialize(new Vector3(16, 0, 6));

            door = new Door();
            door.Initialize(new Vector3(19.17f, 0, 1), new Vector3(0));         

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

            door2 = new Door();
            door2.Initialize(new Vector3(35.17f, 0, 22), new Vector3(0));

            wall = new Wall();
            wall.Initialize(new Vector3(37, 0, 22));

            wall2 = new Wall();
            wall2.Initialize(new Vector3(27, 0, 22));

            wall3 = new WallRotated();
            wall3.Initialize(new Vector3(42, 0, 22), new Vector3(0, 4.713f, 0));

            wall4 = new WallRotated();
            wall4.Initialize(new Vector3(45, 0, 27), new Vector3(0, 4.713f, 0));

            wall5 = new WallRotated();
            wall5.Initialize(new Vector3(42, 0, 32), new Vector3(0, 4.713f, 0));

            wall6 = new WallSmaller();
            wall6.Initialize(new Vector3(42, 0, 27));

            wall12 = new WallSmaller();
            wall12.Initialize(new Vector3(42, 0, 32));

            wall7 = new WallVisible();
            wall7.Initialize(new Vector3(37, 0, 37), new Vector3(0));

            wall8 = new WallVisible();
            wall8.Initialize(new Vector3(32, 0, 37), new Vector3(0));

            wall9 = new WallVisible();
            wall9.Initialize(new Vector3(27, 0, 22), new Vector3(0, 4.713f, 0));

            wall10 = new WallVisible();
            wall10.Initialize(new Vector3(27, 0, 27), new Vector3(0, 4.713f, 0));

            wall11 = new WallVisible();
            wall11.Initialize(new Vector3(27, 0, 32), new Vector3(0, 4.713f, 0));

            door3 = new Door();
            door3.Initialize(new Vector3(30.17f, 0, 37), new Vector3(0));

            corridor6 = new Corridor();
            corridor6.Initialize(new Vector3(27, 0, 37));

            corridor7 = new Corridor();
            corridor7.Initialize(new Vector3(27, 0, 42));

            corridor3Way2 = new Corridor3Way();
            corridor3Way2.Initialize(new Vector3(27, 0, 52), new Vector3(0, 1.571f, 0));

            column2 = new Column();
            column2.Initialize(new Vector3(27, 0, 47));

            columnRotated2 = new ColumnRotated();
            columnRotated2.Initialize(new Vector3(32, 0, 47));

            corridorRotated5 = new CorridorRotated();
            corridorRotated5.Initialize(new Vector3(22, 0, 52), new Vector3(0, 1.571f, 0));

            cornerRight2 = new CornerRightRotated();
            cornerRight2.Initialize(new Vector3(22, 0, 47), new Vector3(0, 4.713f, 0));

            corridor8 = new Corridor();
            corridor8.Initialize(new Vector3(16, 0, 53));

            roomFloor11 = new RoomFloor();
            roomFloor11.Initialize(new Vector3(16, 0, 58));

            roomFloor12 = new RoomFloor();
            roomFloor12.Initialize(new Vector3(11, 0, 58));

            door4 = new Door();
            door4.Initialize(new Vector3(19.17f, 0, 58), new Vector3(0));

            wall13 = new Wall();
            wall13.Initialize(new Vector3(11, 0, 58));

            wall14 = new WallVisible();
            wall14.Initialize(new Vector3(11, 0, 63), new Vector3(0));

            wall15 = new WallVisible();
            wall15.Initialize(new Vector3(16, 0, 63), new Vector3(0));

            wall16 = new WallVisible();
            wall16.Initialize(new Vector3(11, 0, 58), new Vector3(0, 4.713f, 0));

            wall17 = new WallVisible();
            wall17.Initialize(new Vector3(21, 0, 58), new Vector3(0, 4.713f, 0));

            cornerRight3 = new CornerRightRotated();
            cornerRight3.Initialize(new Vector3(38, 0, 53), new Vector3(0, 3.142f, 0));

            corridor9 = new Corridor();
            corridor9.Initialize(new Vector3(33, 0, 53));

            cornerLeft2 = new CornerLeft();
            cornerLeft2.Initialize(new Vector3(33, 0, 58));

            door5 = new Door();
            door5.Initialize(new Vector3(38.9f, 0, 62.15f), new Vector3(0, 4.713f, 0));

            wall13 = new Wall();
            wall13.Initialize(new Vector3(11, 0, 58));

            wall18 = new Wall();
            wall18.Initialize(new Vector3(39, 0, 59));

            wall19 = new Wall();
            wall19.Initialize(new Vector3(44, 0, 59));

            wall20 = new WallVisible();
            wall20.Initialize(new Vector3(49, 0, 59), new Vector3(0, 4.713f, 0));

            wall21 = new WallShorter();
            wall21.Initialize(new Vector3(39, -4, 64));

            wall22 = new WallShorter();
            wall22.Initialize(new Vector3(44, -4, 64));

            roomFloor13 = new RoomFloor();
            roomFloor13.Initialize(new Vector3(39, 0, 59));

            roomFloor14 = new RoomFloor();
            roomFloor14.Initialize(new Vector3(44, 0, 59));

            roomFloor15 = new RoomFloor();
            roomFloor15.Initialize(new Vector3(39, -4, 64));

            roomFloor16 = new RoomFloor();
            roomFloor16.Initialize(new Vector3(44, -4, 64));

            roomFloor17 = new RoomFloor();
            roomFloor17.Initialize(new Vector3(39, -4, 69));

            roomFloor18 = new RoomFloor();
            roomFloor18.Initialize(new Vector3(44, -4, 69));

            roomFloor19 = new RoomFloor();
            roomFloor19.Initialize(new Vector3(39, -4, 74));

            roomFloor20 = new RoomFloor();
            roomFloor20.Initialize(new Vector3(44, -4, 74));

            roomFloor21 = new RoomFloor();
            roomFloor21.Initialize(new Vector3(39, -4, 79));

            roomFloor22 = new RoomFloor();
            roomFloor22.Initialize(new Vector3(44, -4, 79));

            roomFloor23 = new RoomFloor();
            roomFloor23.Initialize(new Vector3(39, -4, 84));

            roomFloor24 = new RoomFloor();
            roomFloor24.Initialize(new Vector3(44, -4, 84));

            roomFloor25 = new RoomFloorSmallerRotated();
            roomFloor25.Initialize(new Vector3(49, -4, 79));

            //stairs = new Stairs();
            //stairs.Initialize(new Vector3(39, 0, 64));



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
            enemy.LoadContent(content);
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
            corridor6.LoadContent(content);
            corridor7.LoadContent(content);
            corridor8.LoadContent(content);
            corridor9.LoadContent(content);
            cornerLeft.LoadContent(content);
            cornerLeft2.LoadContent(content);
            cornerRight.LoadContent(content);
            cornerRight2.LoadContent(content);
            cornerRight3.LoadContent(content);
            corridorRotated.LoadContent(content);
            corridorRotated2.LoadContent(content);
            corridorRotated3.LoadContent(content);
            corridorRotated4.LoadContent(content);
            corridorRotated5.LoadContent(content);
            corridor3Way.LoadContent(content);
            corridor3Way2.LoadContent(content);
            column.LoadContent(content);
            column2.LoadContent(content);
            columnRotated.LoadContent(content);
            columnRotated2.LoadContent(content);
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
            roomFloor11.LoadContent(content);
            roomFloor12.LoadContent(content);
            roomFloor13.LoadContent(content);
            roomFloor14.LoadContent(content);
            roomFloor15.LoadContent(content);
            roomFloor16.LoadContent(content);
            roomFloor17.LoadContent(content);
            roomFloor18.LoadContent(content);
            roomFloor19.LoadContent(content);
            roomFloor20.LoadContent(content);
            roomFloor21.LoadContent(content);
            roomFloor22.LoadContent(content);
            roomFloor23.LoadContent(content);
            roomFloor24.LoadContent(content);
            roomFloor25.LoadContent(content);
            door2.LoadContent(content);
            wall.LoadContent(content);
            wall2.LoadContent(content);
            wall3.LoadContent(content);
            wall4.LoadContent(content);
            wall5.LoadContent(content);
            wall6.LoadContent(content);
            wall7.LoadContent(content);
            wall8.LoadContent(content);
            wall9.LoadContent(content);
            wall10.LoadContent(content);
            wall11.LoadContent(content);
            wall12.LoadContent(content);
            wall13.LoadContent(content);
            wall14.LoadContent(content);
            wall15.LoadContent(content);
            wall16.LoadContent(content);
            wall17.LoadContent(content);
            wall18.LoadContent(content);
            wall19.LoadContent(content);
            wall20.LoadContent(content);
            wall21.LoadContent(content);
            wall22.LoadContent(content);
            door3.LoadContent(content);
            door4.LoadContent(content);
            door5.LoadContent(content);
            //stairs.LoadContent(content);
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

            if (keyState.IsKeyDown(Keys.N))
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
            //gameObjects[16].GetComponent<BoxCollider>().Draw(projection, graphics, mainCam.view);
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

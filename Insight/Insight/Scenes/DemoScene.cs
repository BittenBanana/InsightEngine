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
        private PrelightingRenderer lightRenderer;

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
        Corridor corridor10;
        CornerLeft cornerLeft;
        CornerLeft cornerLeft2;
        CornerRightRotated cornerRight;
        CornerRightRotated cornerRight2;
        CornerRightRotated cornerRight3;
        CornerRightRotated cornerRight4;
        Corridor corridorRotated;
        Corridor corridorRotated2;
        Corridor corridorRotated3;
        Corridor corridorRotated4;
        Corridor corridorRotated5;
        Corridor corridorRotated6;
        Corridor corridorRotated7;
        Corridor3Way corridor3Way;
        Corridor3Way corridor3Way2;
        Column column;
        ColumnRotated columnRotated;
        Column column2;
        ColumnRotated columnRotated2;
        AnimatedDoor door;
        Door door2;
        Door door3;
        Door door4;
        Door door5;
        DoorSmaller door6;
        Door door7;
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
        RoomFloor roomFloor26;
        RoomFloor roomFloor27;
        RoomFloor roomFloor28;
        RoomFloor roomFloor29;
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
        WallVisibleSmaller wall23;
        WallVisibleSmaller wall24;
        WallVisibleSmaller wall25;
        WallVisibleSmaller wall26;
        WallVisibleSmaller wall27;
        WallVisibleSmaller wall28;
        WallVisibleSmaller wall29;
        WallVisibleSmaller wall30;
        WallVisibleSmaller wall31;
        WallVisibleSmaller wall32;
        WallVisibleSmaller wall33;
        WallSmallerShorter wall34;
        WallSmallerShorter wall35;
        WallVisible wall36;
        WallRotated wall37;
        WallRotated wall38;
        WallRotated wall39;
        WallRotated wall40;
        WallVisible wall41;
        WallVisible wall42;
        WallVisible wall43;
        WallVisible wall44;
        WallVisible wall45;
        WallVisible wall46;
        WallVisible wall47;
        WallVisible wall48;
        WallVisible wall49;
        WallVisible wall50;
        WallVisible wall51;
        WallVisible wall52;
        WallVisible wall53;
        WallVisible wall54;
        Stairs stairs;
        GameObject player;
        Material defaultMaterial;
        GameObject directionalLight;
        ColliderManager colliderManager;
        AmmoPC ammoPC;
        AmmoPC ammoPC2;
        Corridor wall55;

        //GameObject enemy;
        private EnemyPrefab enemy1;
        private GameObject pointLight1;

        int _total_frames = 0;
        float _elapsed_time = 0.0f;
        int _fps = 0;

        private GameObject cameraPivot;

        private float windowWidth;
        private float windowHeight;

        private Effect postEffect;


        public override void Initialize(GraphicsDeviceManager graphicsDevice)
        {
            base.Initialize(graphicsDevice);
            windowWidth = SceneManager.Instance.Dimensions.X;
            windowHeight = SceneManager.Instance.Dimensions.Y;
            pointLight1 = new GameObject(new Vector3(17, 3f, 5), false);
            pointLight1.AddNewComponent<Light>();
            pointLight1.GetComponent<Light>().Color = Color.Cyan;
            pointLight1.GetComponent<Light>().Attenuation = 10;

            player = new GameObject(new Vector3(2, 1.0f, 7), true);
            player.AddNewComponent<MeshRenderer>();
            player.physicLayer = Layer.Player;

            enemy1 = new EnemyPrefab();
            enemy1.Initialize(new Vector3(20, 0, -5));
            
            //player.AddNewComponent<Rigidbody>();

            cameraPivot = new GameObject(player.Transform.Position, false);

            //floor1 = new GameObject(new Vector3(0, 0, 0), false);
            //floor1.AddNewComponent<MeshRenderer>();
            //testPrefab = new TestPrefab();
            //testPrefab.Initialize(new Vector3(0, 0, 2));

            corridor = new Corridor();
            corridor.Initialize(new Vector3(0), new Vector3(0));

            corridor2 = new Corridor();
            corridor2.Initialize(new Vector3(0, 0, 5), new Vector3(0));

            cornerLeft = new CornerLeft();
            cornerLeft.Initialize(new Vector3(0, 0, 10));

            corridorRotated = new Corridor();
            corridorRotated.Initialize(new Vector3(6, 0, 16), new Vector3(0, 1.571f, 0));

            corridorRotated2 = new Corridor();
            corridorRotated2.Initialize(new Vector3(11, 0, 16), new Vector3(0, 1.571f, 0));

            corridorRotated3 = new Corridor();
            corridorRotated3.Initialize(new Vector3(21, 0, 16), new Vector3(0, 1.571f, 0));

            corridorRotated4 = new Corridor();
            corridorRotated4.Initialize(new Vector3(26, 0, 16), new Vector3(0, 1.571f, 0));

            cornerRight = new CornerRightRotated();
            cornerRight.Initialize(new Vector3(37, 0, 17), new Vector3(0, 3.142f, 0));

            corridor3Way = new Corridor3Way();
            corridor3Way.Initialize(new Vector3(16, 0, 16), new Vector3(0, 1.571f, 0));

            corridor3 = new Corridor();
            corridor3.Initialize(new Vector3(16, 0, 1), new Vector3(0));

            corridor4 = new Corridor();
            corridor4.Initialize(new Vector3(16, 0, 6), new Vector3(0));

            door = new AnimatedDoor();
            door.Initialize(new Vector3(16, 0, 1));         

            column = new Column();
            column.Initialize(new Vector3(16, 0, 11));

            columnRotated = new ColumnRotated();
            columnRotated.Initialize(new Vector3(21, 0, 11));

            corridor5 = new Corridor();
            corridor5.Initialize(new Vector3(32, 0, 17), new Vector3(0));

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
            corridor6.Initialize(new Vector3(27, 0, 37), new Vector3(0));

            corridor7 = new Corridor();
            corridor7.Initialize(new Vector3(27, 0, 42), new Vector3(0));

            corridor3Way2 = new Corridor3Way();
            corridor3Way2.Initialize(new Vector3(27, 0, 52), new Vector3(0, 1.571f, 0));

            column2 = new Column();
            column2.Initialize(new Vector3(27, 0, 47));

            columnRotated2 = new ColumnRotated();
            columnRotated2.Initialize(new Vector3(32, 0, 47));

            corridorRotated5 = new Corridor();
            corridorRotated5.Initialize(new Vector3(22, 0, 52), new Vector3(0, 1.571f, 0));

            cornerRight2 = new CornerRightRotated();
            cornerRight2.Initialize(new Vector3(22, 0, 47), new Vector3(0, 4.713f, 0));

            corridor8 = new Corridor();
            corridor8.Initialize(new Vector3(16, 0, 53), new Vector3(0));

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
            corridor9.Initialize(new Vector3(33, 0, 53), new Vector3(0));

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

            wall23 = new WallVisibleSmaller();
            wall23.Initialize(new Vector3(49, -4, 64), new Vector3(0, 4.713f, 0));

            wall24 = new WallVisibleSmaller();
            wall24.Initialize(new Vector3(49, -4, 69), new Vector3(0, 4.713f, 0));

            wall25 = new WallVisibleSmaller();
            wall25.Initialize(new Vector3(49, -4, 74), new Vector3(0, 4.713f, 0));

            wall26 = new WallVisibleSmaller();
            wall26.Initialize(new Vector3(52, -4, 79), new Vector3(0, 4.713f, 0));

            wall27 = new WallVisibleSmaller();
            wall27.Initialize(new Vector3(49, -4, 84), new Vector3(0, 4.713f, 0));

            wall28 = new WallVisibleSmaller();
            wall28.Initialize(new Vector3(39, -4, 64), new Vector3(0, 4.713f, 0));

            wall29 = new WallVisibleSmaller();
            wall29.Initialize(new Vector3(39, -4, 69), new Vector3(0, 4.713f, 0));

            wall30 = new WallVisibleSmaller();
            wall30.Initialize(new Vector3(39, -4, 74), new Vector3(0, 4.713f, 0));

            wall31 = new WallVisibleSmaller();
            wall31.Initialize(new Vector3(39, -4, 84), new Vector3(0, 4.713f, 0));

            wall32 = new WallVisibleSmaller();
            wall32.Initialize(new Vector3(39, -4, 89), new Vector3(0));

            wall33 = new WallVisibleSmaller();
            wall33.Initialize(new Vector3(44, -4, 89), new Vector3(0));

            wall34 = new WallSmallerShorter();
            wall34.Initialize(new Vector3(49, -4, 84), new Vector3(0));

            wall35 = new WallSmallerShorter();
            wall35.Initialize(new Vector3(49, -4, 79), new Vector3(0));

            door6 = new DoorSmaller();
            door6.Initialize(new Vector3(39, -4, 79), new Vector3(0, 4.713f, 0));

            wall36 = new WallVisible();
            wall36.Initialize(new Vector3(49, 0, 64), new Vector3(0, 4.713f, 0));

            wall37 = new WallRotated();
            wall37.Initialize(new Vector3(49, 0, 69), new Vector3(0, 4.713f, 0));

            wall38 = new WallRotated();
            wall38.Initialize(new Vector3(49, 0, 74), new Vector3(0, 4.713f, 0));

            wall39 = new WallRotated();
            wall39.Initialize(new Vector3(49, 0, 79), new Vector3(0, 4.713f, 0));

            wall40 = new WallRotated();
            wall40.Initialize(new Vector3(49, 0, 84), new Vector3(0, 4.713f, 0));

            wall41 = new WallVisible();
            wall41.Initialize(new Vector3(39, 0, 64), new Vector3(0, 4.713f, 0));

            wall42 = new WallVisible();
            wall42.Initialize(new Vector3(39, 0, 69), new Vector3(0, 4.713f, 0));

            wall43 = new WallVisible();
            wall43.Initialize(new Vector3(39, 0, 74), new Vector3(0, 4.713f, 0));

            wall44 = new WallVisible();
            wall44.Initialize(new Vector3(39, 0, 79), new Vector3(0, 4.713f, 0));

            wall45 = new WallVisible();
            wall45.Initialize(new Vector3(39, 0, 84), new Vector3(0, 4.713f, 0));

            wall46 = new WallVisible();
            wall46.Initialize(new Vector3(39, 0, 89), new Vector3(0));

            wall47 = new WallVisible();
            wall47.Initialize(new Vector3(44, 0, 89), new Vector3(0));

            corridorRotated6 = new Corridor();
            corridorRotated6.Initialize(new Vector3(34, -4, 84), new Vector3(0, 1.571f, 0));

            corridorRotated7 = new Corridor();
            corridorRotated7.Initialize(new Vector3(29, -4, 84), new Vector3(0, 1.571f, 0));

            cornerRight4 = new CornerRightRotated();
            cornerRight4.Initialize(new Vector3(29, -4, 79), new Vector3(0, 4.713f, 0));

            corridor10 = new Corridor();
            corridor10.Initialize(new Vector3(23, -4, 85), new Vector3(0));

            door7 = new Door();
            door7.Initialize(new Vector3(26.18f, -4, 90), new Vector3(0));

            roomFloor26 = new RoomFloor();
            roomFloor26.Initialize(new Vector3(23, -4, 90));

            roomFloor27 = new RoomFloor();
            roomFloor27.Initialize(new Vector3(23, -4, 95));

            roomFloor28 = new RoomFloor();
            roomFloor28.Initialize(new Vector3(28, -4, 90));

            roomFloor29 = new RoomFloor();
            roomFloor29.Initialize(new Vector3(28, -4, 95));

            wall48 = new WallVisible();
            wall48.Initialize(new Vector3(28, -4, 90), new Vector3(0));

            wall49 = new WallVisible();
            wall49.Initialize(new Vector3(28, -4, 100), new Vector3(0));

            wall50 = new WallVisible();
            wall50.Initialize(new Vector3(23, -4, 100), new Vector3(0));

            wall51 = new WallVisible();
            wall51.Initialize(new Vector3(33, -4, 90), new Vector3(0, 4.713f, 0));

            wall52 = new WallVisible();
            wall52.Initialize(new Vector3(33, -4, 95), new Vector3(0, 4.713f, 0));

            wall53 = new WallVisible();
            wall53.Initialize(new Vector3(23, -4, 90), new Vector3(0, 4.713f, 0));

            wall54 = new WallVisible();
            wall54.Initialize(new Vector3(23, -4, 95), new Vector3(0, 4.713f, 0));

            ammoPC = new AmmoPC();
            ammoPC.Initialize(new Vector3(0.5f, 0, 8), new Vector3(0, 1.571f, 0));

            ammoPC2 = new AmmoPC();
            ammoPC2.Initialize(new Vector3(36.5f, 0, 19), new Vector3(0, 4.713f, 0));

            wall55 = new Corridor();
            wall55.Initialize(new Vector3(-10, 0, 0), new Vector3(0));


            directionalLight = new GameObject(new Vector3(-5, 5, 0), false);
            directionalLight.AddNewComponent<Light>();
            directionalLight.GetComponent<Light>().Direction = new Vector3(3, -5, 0);
            directionalLight.GetComponent<Light>().Color = Color.White;
            


            gameObjects.Add(pointLight1);
            gameObjects.Add(player);
            gameObjects.Add(directionalLight);
            gameObjects.Add(cameraPivot);


            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), graphics.GraphicsDevice.Viewport.AspectRatio, .1f, 1000f);
            colliderManager = new ColliderManager(gameObjects);
        }

        public override void LoadContent()
        {
            base.LoadContent();
            #region Effects 

            postEffect = content.Load<Effect>("Shaders/black&whitePostProcess");

            Effect effect = content.Load<Effect>("Shaders/PhongBlinnShader");
            defaultMaterial = new DefaultMaterial(effect);
            ((DefaultMaterial)defaultMaterial).LightDirection = directionalLight.GetComponent<Light>().Direction;
            ((DefaultMaterial)defaultMaterial).LightColor = directionalLight.GetComponent<Light>().Color.ToVector3();
            ((DefaultMaterial)defaultMaterial).SpecularColor = directionalLight.GetComponent<Light>().Color.ToVector3();
            #endregion

            List<Renderer> models = new List<Renderer>();
            List<Light> lights = new List<Light>();

            foreach (var o in gameObjects)
            {
                if (o.GetComponent<Renderer>() != null)
                {
                    models.Add(o.GetComponent<Renderer>());
                    o.GetComponent<Renderer>().Material = defaultMaterial;
                }
                if (o.GetComponent<Light>() != null)
                {
                    lights.Add(o.GetComponent<Light>());
                }
            }
            foreach (var item in gameObjects)
            {
                item.LoadContent(content);
            }

            lightRenderer = new PrelightingRenderer(graphics.GraphicsDevice, content);


            //floor1.GetComponent<MeshRenderer>().Load(content, "floor5x5", 1.0f);
            //testPrefab.LoadContent(content);

            player.GetComponent<MeshRenderer>().Load(content, "Models/Konrads/Character/superBoxHero", 1f);

            cameraPivot.AddNewComponent<Camera>();
            cameraPivot.AddNewComponent<CameraPivotFollow>();
            cameraPivot.GetComponent<CameraPivotFollow>().player = player;
            player.AddNewComponent<RaycastTest>();

            player.AddNewComponent<BoxController>();
            cameraPivot.AddNewComponent<CameraFollowBox>();
            cameraPivot.GetComponent<CameraFollowBox>().player = player;
            mainCam = cameraPivot.GetComponent<Camera>();
            player.AddNewComponent<SphereCollider>();
            player.AddNewComponent<PlayerBullets>();
            corridor.LoadContent(content);
            corridor2.LoadContent(content);
            corridor3.LoadContent(content);
            corridor4.LoadContent(content);
            corridor5.LoadContent(content);
            corridor6.LoadContent(content);
            corridor7.LoadContent(content);
            corridor8.LoadContent(content);
            corridor9.LoadContent(content);
            corridor10.LoadContent(content);
            cornerLeft.LoadContent(content);
            cornerLeft2.LoadContent(content);
            cornerRight.LoadContent(content);
            cornerRight2.LoadContent(content);
            cornerRight3.LoadContent(content);
            cornerRight4.LoadContent(content);
            corridorRotated.LoadContent(content);
            corridorRotated2.LoadContent(content);
            corridorRotated3.LoadContent(content);
            corridorRotated4.LoadContent(content);
            corridorRotated5.LoadContent(content);
            corridorRotated6.LoadContent(content);
            corridorRotated7.LoadContent(content);
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
            roomFloor26.LoadContent(content);
            roomFloor27.LoadContent(content);
            roomFloor28.LoadContent(content);
            roomFloor29.LoadContent(content);
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
            wall23.LoadContent(content);
            wall24.LoadContent(content);
            wall25.LoadContent(content);
            wall26.LoadContent(content);
            wall27.LoadContent(content);
            wall28.LoadContent(content);
            wall29.LoadContent(content);
            wall30.LoadContent(content);
            wall31.LoadContent(content);
            wall32.LoadContent(content);
            wall33.LoadContent(content);
            wall34.LoadContent(content);
            wall35.LoadContent(content);
            wall36.LoadContent(content);
            wall37.LoadContent(content);
            wall38.LoadContent(content);
            wall39.LoadContent(content);
            wall40.LoadContent(content);
            wall41.LoadContent(content);
            wall42.LoadContent(content);
            wall43.LoadContent(content);
            wall44.LoadContent(content);
            wall45.LoadContent(content);
            wall46.LoadContent(content);
            wall47.LoadContent(content);
            wall48.LoadContent(content);
            wall49.LoadContent(content);
            wall50.LoadContent(content);
            wall51.LoadContent(content);
            wall52.LoadContent(content);
            wall53.LoadContent(content);
            wall54.LoadContent(content);
            wall55.LoadContent(content);
            door3.LoadContent(content);
            door4.LoadContent(content);
            door5.LoadContent(content);
            door6.LoadContent(content);
            door7.LoadContent(content);
            ammoPC.LoadContent(content);
            ammoPC2.LoadContent(content);
            //stairs.LoadContent(content);
            //colliderManager.ObjectColided += player.OnObjectColided;

            enemy1.LoadContent(content);
            ui = new UserInterface(player, graphics.GraphicsDevice, content);
            ui.AddText("Fonts/gamefont", "generalFont", string.Format("FPS={0}", _fps), new Vector2(10, 20), Color.White, 1);

            ui.AddSprite("Sprites/rakieta", "aggresive", new Vector2(30, windowHeight - 70), Color.White, 1);
            ui.AddSprite("Sprites/skarbonka", "transmitter", new Vector2(90, windowHeight - 68), Color.White, 1);
            ui.AddSprite("Sprites/monitor", "sight", new Vector2(150, windowHeight - 66), Color.White, 1);

            ui.AddSprite("Sprites/blood", "blood", new Vector2(0, 0), Color.White, 0);

            ui.AddSprite("Sprites/rakieta", "bulletRakieta", new Vector2(windowWidth / 2, windowHeight / 2 - 150), Color.White, 0);
            ui.AddText("Fonts/gamefont", "hint", "Press E to open doors", new Vector2(windowWidth / 2 - 50, windowHeight / 2 - 100), Color.White, 0);
            ui.AddText("Fonts/gamefont", "dispenserHint", "Press E to take the bullet", new Vector2(windowWidth / 2 - 50, windowHeight / 2 - 100), Color.White, 0);

            ui.AddSprite("Sprites/crosshair", "crosshair", new Vector2(windowWidth / 2 - 16, windowHeight / 2 - 16), Color.White, 1);

            lightRenderer.Camera = mainCam;
            lightRenderer.Lights = lights;
            lightRenderer.Models = models;

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
            if (player.GetComponent<PlayerBullets>().aggresiveBullet)
                ui.ChangeSpriteOpacity("aggresive", 1);
            else
                ui.ChangeSpriteOpacity("aggresive", 0);

            if (player.GetComponent<PlayerBullets>().transmitterBullet)
                ui.ChangeSpriteOpacity("transmitter", 1);
            else
                ui.ChangeSpriteOpacity("transmitter", 0);

            if (player.GetComponent<PlayerBullets>().enemySightBullet)
                ui.ChangeSpriteOpacity("sight", 1);
            else
                ui.ChangeSpriteOpacity("sight", 0);

            //Debug.WriteLine(mainCam.Position);
        }

        public override void Draw()
        {
            lightRenderer.Draw();

            graphics.GraphicsDevice.Clear(Color.LightBlue);
            foreach (GameObject go in gameObjects)
            {
                go.Draw(mainCam);
                //if(go.GetComponent<BoxCollider>() != null)
                //go.GetComponent<BoxCollider>().Draw(projection,graphics, mainCam.view);
            }
            ui.Draw();
            //dispenserTrigger.GetComponent<BoxCollider>().Draw(projection, graphics, mainCam.view);
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

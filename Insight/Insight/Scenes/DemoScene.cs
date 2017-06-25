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
using Insight.Engine.Prefabs.UI;

namespace Insight.Scenes
{
    class DemoScene : GameScene
    {
        private PrelightingRenderer lightRenderer;

        private PostProcessRenderer postProcessRenderer;

        private RenderTarget2D sceneRenderTarget2D;

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
        AnimatedDoor door2;
        AnimatedDoor door3;
        AnimatedDoor door4;
        AnimatedDoor door5;
        DoorSmaller door6;
        
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
        
        Stairs stairs;
        Stairs stairs2;
        Material defaultMaterial;
        GameObject directionalLight;
        ColliderManager colliderManager;
        AmmoPC ammoPC;
        AmmoPC ammoPC2;
        Corridor wall55;
        AmmoPCMark ammoPC3;
        AmmoPCMark ammoPC4;
        AmmoPCMark ammoPC5;
        AmmoPC ammoPC6;
        AmmoPC ammoPC7;
        Crate crate;
        Crate crate2;
        Crate crate3;
        Crate crate4;
        Crate crate5;
        Crate crate6;
        Crate crate7;
        Crate crate8;
        Crate crate9;
        Crate crate10;
        Crate crate11;
        Crate crate12;
        Crate crate13;
        Crate crate14;
        Crate crate15;
        Crate crate16;
        Crate crate17;
        Crate crate18;
        Crate crate19;
        Crate crate20;
        Desk2Monitors desk2Monitors;
        Desk2Monitors desk2Monitors2;
        Desk2Monitors desk2Monitors3;
        Desk2Monitors desk2Monitors4;
        Intercom intercom;
        BigMachine bigMachine;
        UpperStairsTrigger upperStairsTrigger;
        LowerStairsTrigger lowerStairsTrigger;
        LastRoom lastRoom;

        //GameObject enemy;
        private EnemyPrefab enemy1;
        private StandingEnemy enemyStanding;
        private EnemyPrefab walkingEnemyInRoom;
        private StandingEnemy standingEnemyNearPcInRoom1;
        private StandingEnemy standingEnemyNearPcInRoom2;
        private GameObject pointLight1;
        private GameObject pointLight2;
        private GameObject pointLight3;
        private GameObject pointLight4;
        private GameObject pointLight5;
        private GameObject pointLight6;
        private GameObject pointLight7;
        private GameObject pointLight8;

        int _total_frames = 0;
        float _elapsed_time = 0.0f;
        int _fps = 0;

        private GameObject cameraPivot;

        private float windowWidth;
        private float windowHeight;

        private Effect postEffect;

        SightSlider sightSlider;
        AmmoInterface ammoInterface;

        public override void Initialize(GraphicsDeviceManager graphicsDevice)
        {
            base.Initialize(graphicsDevice);

            

            gameOver = false;
            sceneRenderTarget2D = new RenderTarget2D(graphics.GraphicsDevice, graphics.GraphicsDevice.Viewport.Width,
                    graphics.GraphicsDevice.Viewport.Height, false, SurfaceFormat.Color, DepthFormat.Depth24);

            windowWidth = SceneManager.Instance.Dimensions.X;
            windowHeight = SceneManager.Instance.Dimensions.Y;
            pointLight1 = new GameObject(new Vector3(18.5f, 3f, 5), false);
            pointLight1.AddNewComponent<Light>();
            pointLight1.GetComponent<Light>().Color = Color.LightYellow;
            pointLight1.GetComponent<Light>().Attenuation = 7.5f;

            pointLight2 = new GameObject(new Vector3(2.5f, 3f, 2.5f), false);
            pointLight2.AddNewComponent<Light>();
            pointLight2.GetComponent<Light>().Color = Color.LightYellow;
            pointLight2.GetComponent<Light>().Attenuation = 7.5f;

            pointLight3 = new GameObject(new Vector3(2.5f, 3f, 12.5f), false);
            pointLight3.AddNewComponent<Light>();
            pointLight3.GetComponent<Light>().Color = Color.LightYellow;
            pointLight3.GetComponent<Light>().Attenuation = 7.5f;

            pointLight4 = new GameObject(new Vector3(12.5f, 3f, 13.5f), false);
            pointLight4.AddNewComponent<Light>();
            pointLight4.GetComponent<Light>().Color = Color.LightYellow;
            pointLight4.GetComponent<Light>().Attenuation = 7.5f;

            pointLight5 = new GameObject(new Vector3(22.5f, 3f, 13.5f), false);
            pointLight5.AddNewComponent<Light>();
            pointLight5.GetComponent<Light>().Color = Color.LightYellow;
            pointLight5.GetComponent<Light>().Attenuation = 7.5f;

            pointLight6 = new GameObject(new Vector3(32.5f, 3f, 13.5f), false);
            pointLight6.AddNewComponent<Light>();
            pointLight6.GetComponent<Light>().Color = Color.LightYellow;
            pointLight6.GetComponent<Light>().Attenuation = 7.5f;

            player = new GameObject(new Vector3(2, 0.1f, 7), true);
            player.AddNewComponent<AnimationRender>();
            player.AddNewComponent<PlayerManager>();
            player.physicLayer = Layer.Player;


            List<Vector3> enemy1PatrolPositions = new List<Vector3>();
            enemy1PatrolPositions.Add(new Vector3(18.5f, 0, 6f));
            enemy1PatrolPositions.Add(new Vector3(18.5f, 0, 13.5f));
            enemy1 = new EnemyPrefab(enemy1PatrolPositions);
            enemy1.Initialize(new Vector3(18.5f, 0, 6f));
            
            
            enemyStanding = new StandingEnemy();
            enemyStanding.Initialize(new Vector3(18.5f, 0, 13.5f));

            List<Vector3> walkingEnemyPatrolPositions = new List<Vector3>();
            walkingEnemyPatrolPositions.Add(new Vector3(29.5f, 0, 34f));
            walkingEnemyPatrolPositions.Add(new Vector3(37.5f, 0, 32f));
            walkingEnemyPatrolPositions.Add(new Vector3(38f, 0, 32f));
            walkingEnemyPatrolPositions.Add(new Vector3(38f, 0, 31f));
            walkingEnemyPatrolPositions.Add(new Vector3(35f, 0, 34f));
            walkingEnemyInRoom = new EnemyPrefab(walkingEnemyPatrolPositions);
            walkingEnemyInRoom.Initialize(new Vector3(29.5f, 0, 34));

            standingEnemyNearPcInRoom1 = new StandingEnemy();
            standingEnemyNearPcInRoom1.Initialize(new Vector3(28.5f, 0, 35.5f));

            standingEnemyNearPcInRoom2 = new StandingEnemy();
            standingEnemyNearPcInRoom2.Initialize(new Vector3(28.5f, 0, 34f));

            player.AddNewComponent<Rigidbody>();

            player.GetComponent<Rigidbody>().useGravity = false;

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

            door2 = new AnimatedDoor();
            door2.Initialize(new Vector3(32f, 0, 22));

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

            door3 = new AnimatedDoor();
            door3.Initialize(new Vector3(27f, 0, 37));

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

            door4 = new AnimatedDoor();
            door4.Initialize(new Vector3(16f, 0, 58));

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

            door5 = new AnimatedDoor();
            door5.Initialize(new Vector3(35f, 0, 62.15f), new Vector3(0, 4.713f, 0));

            wall13 = new Wall();
            wall13.Initialize(new Vector3(11, 0, 58));

            //wall18 = new Wall();
            //wall18.Initialize(new Vector3(39, 0, 59));

            //wall19 = new Wall();
            //wall19.Initialize(new Vector3(44, 0, 59));

            //wall20 = new WallVisible();
            //wall20.Initialize(new Vector3(49, 0, 59), new Vector3(0, 4.713f, 0));

            //wall21 = new WallShorter();
            //wall21.Initialize(new Vector3(39, -4, 64));

            //wall22 = new WallShorter();
            //wall22.Initialize(new Vector3(44, -4, 64));

            //roomFloor13 = new RoomFloor();
            //roomFloor13.Initialize(new Vector3(39, 0, 59));

            //roomFloor14 = new RoomFloor();
            //roomFloor14.Initialize(new Vector3(44, 0, 59));

            //roomFloor15 = new RoomFloor();
            //roomFloor15.Initialize(new Vector3(39, -4, 64));

            //roomFloor16 = new RoomFloor();
            //roomFloor16.Initialize(new Vector3(44, -4, 64));

            //roomFloor17 = new RoomFloor();
            //roomFloor17.Initialize(new Vector3(39, -4, 69));

            //roomFloor18 = new RoomFloor();
            //roomFloor18.Initialize(new Vector3(44, -4, 69));

            //roomFloor19 = new RoomFloor();
            //roomFloor19.Initialize(new Vector3(39, -4, 74));

            //roomFloor20 = new RoomFloor();
            //roomFloor20.Initialize(new Vector3(44, -4, 74));

            //roomFloor21 = new RoomFloor();
            //roomFloor21.Initialize(new Vector3(39, -4, 79));

            //roomFloor22 = new RoomFloor();
            //roomFloor22.Initialize(new Vector3(44, -4, 79));

            //roomFloor23 = new RoomFloor();
            //roomFloor23.Initialize(new Vector3(39, -4, 84));

            //roomFloor24 = new RoomFloor();
            //roomFloor24.Initialize(new Vector3(44, -4, 84));

            //roomFloor25 = new RoomFloorSmallerRotated();
            //roomFloor25.Initialize(new Vector3(49, -4, 79));

            //stairs = new Stairs();
            //stairs.Initialize(new Vector3(42, -4, 64), new Vector3(0, 4.713f, 0));

            //stairs2 = new Stairs();
            //stairs2.Initialize(new Vector3(49, -4, 64), new Vector3(0, 4.713f, 0));

            //upperStairsTrigger = new UpperStairsTrigger();
            //upperStairsTrigger.Initialize(new Vector3(41, 1, 65.5f));

            //lowerStairsTrigger = new LowerStairsTrigger();
            //lowerStairsTrigger.Initialize(new Vector3(41, -4, 73f));

            //wall23 = new WallVisibleSmaller();
            //wall23.Initialize(new Vector3(49, -4, 64), new Vector3(0, 4.713f, 0));

            //wall24 = new WallVisibleSmaller();
            //wall24.Initialize(new Vector3(49, -4, 69), new Vector3(0, 4.713f, 0));

            //wall25 = new WallVisibleSmaller();
            //wall25.Initialize(new Vector3(49, -4, 74), new Vector3(0, 4.713f, 0));

            //wall26 = new WallVisibleSmaller();
            //wall26.Initialize(new Vector3(52, -4, 79), new Vector3(0, 4.713f, 0));

            //wall27 = new WallVisibleSmaller();
            //wall27.Initialize(new Vector3(49, -4, 84), new Vector3(0, 4.713f, 0));

            //wall28 = new WallVisibleSmaller();
            //wall28.Initialize(new Vector3(39, -4, 64), new Vector3(0, 4.713f, 0));

            //wall29 = new WallVisibleSmaller();
            //wall29.Initialize(new Vector3(39, -4, 69), new Vector3(0, 4.713f, 0));

            //wall30 = new WallVisibleSmaller();
            //wall30.Initialize(new Vector3(39, -4, 74), new Vector3(0, 4.713f, 0));

            //wall31 = new WallVisibleSmaller();
            //wall31.Initialize(new Vector3(39, -4, 84), new Vector3(0, 4.713f, 0));

            //wall32 = new WallVisibleSmaller();
            //wall32.Initialize(new Vector3(39, -4, 89), new Vector3(0));

            //wall33 = new WallVisibleSmaller();
            //wall33.Initialize(new Vector3(44, -4, 89), new Vector3(0));

            //wall34 = new WallSmallerShorter();
            //wall34.Initialize(new Vector3(49, -4, 84), new Vector3(0));

            //wall35 = new WallSmallerShorter();
            //wall35.Initialize(new Vector3(49, -4, 79), new Vector3(0));

            door6 = new DoorSmaller();
            door6.Initialize(new Vector3(39, -4, 79), new Vector3(0, 4.713f, 0));

            //wall36 = new WallVisible();
            //wall36.Initialize(new Vector3(49, 0, 64), new Vector3(0, 4.713f, 0));

            //wall37 = new WallRotated();
            //wall37.Initialize(new Vector3(49, 0, 69), new Vector3(0, 4.713f, 0));

            //wall38 = new WallRotated();
            //wall38.Initialize(new Vector3(49, 0, 74), new Vector3(0, 4.713f, 0));

            //wall39 = new WallRotated();
            //wall39.Initialize(new Vector3(49, 0, 79), new Vector3(0, 4.713f, 0));

            //wall40 = new WallRotated();
            //wall40.Initialize(new Vector3(49, 0, 84), new Vector3(0, 4.713f, 0));

            //wall41 = new WallVisible();
            //wall41.Initialize(new Vector3(39, 0, 64), new Vector3(0, 4.713f, 0));

            //wall42 = new WallVisible();
            //wall42.Initialize(new Vector3(39, 0, 69), new Vector3(0, 4.713f, 0));

            //wall43 = new WallVisible();
            //wall43.Initialize(new Vector3(39, 0, 74), new Vector3(0, 4.713f, 0));

            //wall44 = new WallVisible();
            //wall44.Initialize(new Vector3(39, 0, 79), new Vector3(0, 4.713f, 0));

            //wall45 = new WallVisible();
            //wall45.Initialize(new Vector3(39, 0, 84), new Vector3(0, 4.713f, 0));

            //wall46 = new WallVisible();
            //wall46.Initialize(new Vector3(39, 0, 89), new Vector3(0));

            //wall47 = new WallVisible();
            //wall47.Initialize(new Vector3(44, 0, 89), new Vector3(0));

            //corridorRotated6 = new Corridor();
            //corridorRotated6.Initialize(new Vector3(34, -4, 84), new Vector3(0, 1.571f, 0));

            //corridorRotated7 = new Corridor();
            //corridorRotated7.Initialize(new Vector3(29, -4, 84), new Vector3(0, 1.571f, 0));

            //cornerRight4 = new CornerRightRotated();
            //cornerRight4.Initialize(new Vector3(29, -4, 79), new Vector3(0, 4.713f, 0));

            //corridor10 = new Corridor();
            //corridor10.Initialize(new Vector3(23, -4, 85), new Vector3(0));

           

            

            

            ammoPC = new AmmoPC();
            ammoPC.Initialize(new Vector3(0.5f, 0, 8), new Vector3(0, 1.571f, 0));

            ammoPC2 = new AmmoPC();
            ammoPC2.Initialize(new Vector3(36.5f, 0, 19), new Vector3(0, 4.713f, 0));

            ammoPC3 = new AmmoPCMark();
            ammoPC3.Initialize(new Vector3(11f, 0, 60.5f), new Vector3(0, 1.571f, 0));

            //ammoPC4 = new AmmoPCMark();
            //ammoPC4.Initialize(new Vector3(49f, 0, 61f), new Vector3(0, 4.713f, 0));

            //ammoPC5 = new AmmoPCMark();
            //ammoPC5.Initialize(new Vector3(42f, -4, 68f), new Vector3(0, 1.571f, 0));

            //ammoPC6 = new AmmoPC();
            //ammoPC6.Initialize(new Vector3(52f, -4, 82f), new Vector3(0, 4.713f, 0));

            //ammoPC7 = new AmmoPC();
            //ammoPC7.Initialize(new Vector3(47f, -4, 89f), new Vector3(0, 3.142f, 0));

            wall55 = new Corridor();
            wall55.Initialize(new Vector3(-10, 0, 0), new Vector3(0));

            crate = new Crate();
            crate.Initialize(new Vector3(31, 0, 25.5f), new Vector3(0, 0, 0));

            bigMachine = new BigMachine();
            bigMachine.Initialize(new Vector3(27, 0, 26), new Vector3(0, 1.571f, 0));

            desk2Monitors = new Desk2Monitors();
            desk2Monitors.Initialize(new Vector3(42, 0, 27), new Vector3(0));

            desk2Monitors2 = new Desk2Monitors();
            desk2Monitors2.Initialize(new Vector3(27.1f, 0, 35), new Vector3(0, 1.571f, 0));

            desk2Monitors3 = new Desk2Monitors();
            desk2Monitors3.Initialize(new Vector3(21, 0, 60), new Vector3(0, 4.713f, 0));

            desk2Monitors4 = new Desk2Monitors();
            desk2Monitors4.Initialize(new Vector3(19, 0, 15.5f), new Vector3(0, 3.142f, 0));

            intercom = new Intercom();
            intercom.Initialize(new Vector3(39, -0.5f, 36.9f), new Vector3(0, 3.142f, 0));
            //crate2 = new Crate();
            //crate2.Initialize(new Vector3(42, 0, 62f), new Vector3(0));

            //crate3 = new Crate();
            //crate3.Initialize(new Vector3(41.5f, 0, 62f), new Vector3(0));

            //crate4 = new Crate();
            //crate4.Initialize(new Vector3(41.5f, 0, 61.5f), new Vector3(0));

            //crate5 = new Crate();
            //crate5.Initialize(new Vector3(42, 0, 61.5f), new Vector3(0));

            //crate6 = new Crate();
            //crate6.Initialize(new Vector3(41.5f, 0.5f, 62f), new Vector3(0, 1, 0));

            //crate7 = new Crate();
            //crate7.Initialize(new Vector3(44.5f, 0, 61.5f), new Vector3(0, 0, 0));

            //crate8 = new Crate();
            //crate8.Initialize(new Vector3(45f, 0, 61.5f), new Vector3(0, 0, 0));

            //crate9 = new Crate();
            //crate9.Initialize(new Vector3(45f, -4, 73f), new Vector3(0, 0, 0));

            //crate10 = new Crate();
            //crate10.Initialize(new Vector3(44.5f, -4, 73f), new Vector3(0, 0, 0));

            //crate11 = new Crate();
            //crate11.Initialize(new Vector3(44.5f, -3.5f, 73f), new Vector3(0, 0, 0));

            //crate12 = new Crate();
            //crate12.Initialize(new Vector3(45f, -4, 65f), new Vector3(0, 0, 0));

            //crate13 = new Crate();
            //crate13.Initialize(new Vector3(45f, -4, 83.5f), new Vector3(0, 0, 0));

            //crate14 = new Crate();
            //crate14.Initialize(new Vector3(45f, -4, 83f), new Vector3(0, 0, 0));

            //crate15 = new Crate();
            //crate15.Initialize(new Vector3(41.5f, -4, 78.5f), new Vector3(0, 0, 0));

            //crate16 = new Crate();
            //crate16.Initialize(new Vector3(41.5f, -4, 78f), new Vector3(0, 0, 0));

            //crate17 = new Crate();
            //crate17.Initialize(new Vector3(42f, -4, 78f), new Vector3(0, 0, 0));

            //crate18 = new Crate();
            //crate18.Initialize(new Vector3(41.7f, -3.5f, 78f), new Vector3(0, 1, 0));

            //crate19 = new Crate();
            //crate19.Initialize(new Vector3(42f, -4, 77.5f), new Vector3(0, 0, 0));

            //crate20 = new Crate();
            //crate20.Initialize(new Vector3(41.5f, -4, 77.5f), new Vector3(0, 0, 0));

            lastRoom = new LastRoom();
            lastRoom.Initialize(new Vector3(20, 4, -30));

            directionalLight = new GameObject(new Vector3(-5, 5, 0), false);
            directionalLight.AddNewComponent<Light>();
            directionalLight.GetComponent<Light>().Direction = new Vector3(3, -5, 0);
            directionalLight.GetComponent<Light>().Color = Color.White;

            //audioManager = new AudioManager(cameraPivot, content);

            gameObjects.Add(pointLight1);
            gameObjects.Add(pointLight2);
            gameObjects.Add(pointLight3);
            gameObjects.Add(pointLight4);
            gameObjects.Add(pointLight5);
            gameObjects.Add(pointLight6);
            gameObjects.Add(player);
            gameObjects.Add(directionalLight);
            gameObjects.Add(cameraPivot);


            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), graphics.GraphicsDevice.Viewport.AspectRatio,0.5f, 1000f);
            colliderManager = new ColliderManager(gameObjects);
        }

        public override void LoadContent()
        {
            base.LoadContent();

            

            #region Effects 

            postEffect = content.Load<Effect>("Shaders/black&whitePostProcess");
            postEffect.Parameters["BloodTexture1"]?.SetValue(content.Load<Texture2D>("Sprites/1stHit"));
            postEffect.Parameters["BloodTexture2"]?.SetValue(content.Load<Texture2D>("Sprites/2ndHit"));
            postEffect.Parameters["BloodTexture3"]?.SetValue(content.Load<Texture2D>("Sprites/3rdHit"));

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

            if (postEffect != null)
                postProcessRenderer = new PostProcessRenderer(graphics.GraphicsDevice, postEffect);


            //floor1.GetComponent<MeshRenderer>().Load(content, "floor5x5", 1.0f);
            //testPrefab.LoadContent(content);

            //player.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.superBoxHero, 1f);
            player.GetComponent<AnimationRender>().Load(content, AnimationRender.AnimationModel.Player);
            player.GetComponent<AnimationRender>().LoadAmbientOcclusionMap(content, "Materials/postacUV_2_DefaultMaterial_AO");
            player.GetComponent<AnimationRender>().LoadMetalnessMap(content, "Materials/postacUV_2_DefaultMaterial_MetallicSmoothness");
            player.GetComponent<AnimationRender>().LoadNormalMap(content, "Materials/postacUV_2_DefaultMaterial_Normal");
            player.GetComponent<AnimationRender>().LoadTexture(content, "Materials/postacUV_2_DefaultMaterial_AlbedoTransparency");
            //playerAnimRun.Load(content, "Models/Konrads/Character/postacRunGun", 30);
            //playerAnimIdle.Load(content, "Models/Konrads/Character/postacIdleGun", 60);

            //player.ReplaceAnimationRendrer(playerAnimIdle);

            cameraPivot.AddNewComponent<Camera>();
            cameraPivot.AddNewComponent<CameraPivotFollow>();
            cameraPivot.GetComponent<CameraPivotFollow>().player = player;
            
            

            player.AddNewComponent<BoxController>();
            cameraPivot.AddNewComponent<CameraFollowBox>();
            cameraPivot.GetComponent<CameraFollowBox>().player = player;
            mainCam = cameraPivot.GetComponent<Camera>();

            audioManager = new AudioManager(player, content);

            player.AddNewComponent<RaycastTest>();
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
            //corridor10.LoadContent(content);
            cornerLeft.LoadContent(content);
            cornerLeft2.LoadContent(content);
            cornerRight.LoadContent(content);
            cornerRight2.LoadContent(content);
            cornerRight3.LoadContent(content);
            //cornerRight4.LoadContent(content);
            corridorRotated.LoadContent(content);
            corridorRotated2.LoadContent(content);
            corridorRotated3.LoadContent(content);
            corridorRotated4.LoadContent(content);
            corridorRotated5.LoadContent(content);
            //corridorRotated6.LoadContent(content);
            //corridorRotated7.LoadContent(content);
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
            //roomFloor13.LoadContent(content);
            //roomFloor14.LoadContent(content);
            //roomFloor15.LoadContent(content);
            //roomFloor16.LoadContent(content);
            //roomFloor17.LoadContent(content);
            //roomFloor18.LoadContent(content);
            //roomFloor19.LoadContent(content);
            //roomFloor20.LoadContent(content);
            //roomFloor21.LoadContent(content);
            //roomFloor22.LoadContent(content);
            //roomFloor23.LoadContent(content);
            //roomFloor24.LoadContent(content);
            //roomFloor25.LoadContent(content);
            
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
            //wall18.LoadContent(content);
            //wall19.LoadContent(content);
            //wall20.LoadContent(content);
            //wall21.LoadContent(content);
            //wall22.LoadContent(content);
            //wall23.LoadContent(content);
            //wall24.LoadContent(content);
            //wall25.LoadContent(content);
            //wall26.LoadContent(content);
            //wall27.LoadContent(content);
            //wall28.LoadContent(content);
            //wall29.LoadContent(content);
            //wall30.LoadContent(content);
            //wall31.LoadContent(content);
            //wall32.LoadContent(content);
            //wall33.LoadContent(content);
            //wall34.LoadContent(content);
            //wall35.LoadContent(content);
            //wall36.LoadContent(content);
            //wall37.LoadContent(content);
            //wall38.LoadContent(content);
            //wall39.LoadContent(content);
            //wall40.LoadContent(content);
            //wall41.LoadContent(content);
            //wall42.LoadContent(content);
            //wall43.LoadContent(content);
            //wall44.LoadContent(content);
            //wall45.LoadContent(content);
            //wall46.LoadContent(content);
            //wall47.LoadContent(content);
            
            wall55.LoadContent(content);
            door3.LoadContent(content);
            door4.LoadContent(content);
            door5.LoadContent(content);
            //door6.LoadContent(content);
            
            ammoPC.LoadContent(content);
            ammoPC2.LoadContent(content);
            ammoPC3.LoadContent(content);
            //ammoPC4.LoadContent(content);
            //ammoPC5.LoadContent(content);
            //ammoPC6.LoadContent(content);
            //ammoPC7.LoadContent(content);
            crate.LoadContent(content);
            //crate2.LoadContent(content);
            //crate3.LoadContent(content);
            //crate4.LoadContent(content);
            //crate5.LoadContent(content);
            //crate6.LoadContent(content);
            //crate7.LoadContent(content);
            //crate8.LoadContent(content);
            //crate9.LoadContent(content);
            //crate10.LoadContent(content);
            //crate11.LoadContent(content);
            //crate12.LoadContent(content);
            //crate13.LoadContent(content);
            //crate14.LoadContent(content);
            //crate15.LoadContent(content);
            //crate16.LoadContent(content);
            //crate17.LoadContent(content);
            //crate18.LoadContent(content);
            //crate19.LoadContent(content);
            //crate20.LoadContent(content);
            desk2Monitors.LoadContent(content);
            desk2Monitors2.LoadContent(content);
            desk2Monitors3.LoadContent(content);
            desk2Monitors4.LoadContent(content);
            intercom.LoadContent(content);
            door3.wallModel.GetComponent<DoorAnimation>().canOpen = false;
            intercom.SetDoorsToTrigger(door3.wallModel);

            //stairs.LoadContent(content);
            //stairs2.LoadContent(content);
            bigMachine.LoadContent(content);
            //upperStairsTrigger.LoadContent(content);
            //lowerStairsTrigger.LoadContent(content);
            //colliderManager.ObjectColided += player.OnObjectColided;
            lastRoom.LoadContent(content);
            enemy1.LoadContent(content);
            enemyStanding.LoadContent(content);
            standingEnemyNearPcInRoom1.LoadContent(content);
            standingEnemyNearPcInRoom2.LoadContent(content);
            walkingEnemyInRoom.LoadContent(content);
            ui = new UserInterface(graphics.GraphicsDevice, content);
            //ui.AddText("Fonts/gamefont", "generalFont", string.Format("FPS={0}", _fps), new Vector2(10, 20), Color.White, 1);




            //ui.AddSprite("Sprites/blood", "blood", new Vector2(0, 0), Color.White, 0);
            SceneManager.Instance.currentScene.ui.AddText("Fonts/gamefont", "doorHint", "Press E to open doors",
                                    new Vector2(windowWidth / 2 - 50, windowHeight / 2 - 100), Color.White, 0);

            ui.AddSprite("Sprites/GUI/ikona_agresja", "bulletRakieta", new Vector2(windowWidth / 2, windowHeight / 2 - 150), Color.White, 0);
            ui.AddText("Fonts/gamefont", "hint", "Press E to open doors", new Vector2(windowWidth / 2 - 50, windowHeight / 2 - 100), Color.White, 0);
            ui.AddText("Fonts/gamefont", "dispenserHint", "Press E to take the bullet", new Vector2(windowWidth / 2 - 50, windowHeight / 2 - 100), Color.White, 0);
            ui.AddText("Fonts/gamefont", "gameOver", "GAME OVER", new Vector2(windowWidth / 2 - 50, windowHeight / 2 - 100), Color.White, 0);

            ui.AddSprite("Sprites/crosshair", "crosshair", new Vector2(windowWidth / 2 - 16, windowHeight / 2 - 16), Color.White, 1);

            sightSlider = new SightSlider(ui, windowWidth, windowHeight);
            ammoInterface = new AmmoInterface(ui, windowHeight, windowHeight);

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

            if (!gameOver)
            {
                foreach (GameObject go in gameObjects)
                {
                    go.Update();
                }
                colliderManager.Update();

                //float lerped = MathHelper.Lerp(postEffect.Parameters["colorPercentage"].GetValueSingle(),
                //    1 - ((float)player.GetComponent<PlayerManager>().health / 100), Time.deltaTime);
                postEffect.Parameters["colorPercentage"]?.SetValue(1 - ((float)player.GetComponent<PlayerManager>().health / 100));

                //mui.ChangeText("generalFont", string.Format("FPS={0}", _fps));

                // Update
                _elapsed_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                // 1 Second has passed
                if (_elapsed_time >= 1000.0f)
                {
                    _fps = _total_frames;
                    _total_frames = 0;
                    _elapsed_time = 0;
                }

                if (player.GetComponent<PlayerBullets>().aggresiveBullet)
                    ui.ChangeSpriteOpacity("agresja_a", 1);
                else
                    ui.ChangeSpriteOpacity("agresja_a", 0);

                if (player.GetComponent<PlayerBullets>().transmitterBullet)
                    ui.ChangeSpriteOpacity("marker_a", 1);
                else
                    ui.ChangeSpriteOpacity("marker_a", 0);

                if (player.GetComponent<PlayerBullets>().paralysisBullet)
                    ui.ChangeSpriteOpacity("oko_a", 1);
                else
                    ui.ChangeSpriteOpacity("oko_a", 0);

                //Debug.WriteLine(mainCam.Position);
                if(gameOver)
                    ui.ChangeTextOpacity("gameOver", 1);
                
                sightSlider.SetSightLevel(player.GetComponent<PlayerManager>().detectionLevel);

                switch (player.GetComponent<RaycastTest>().GetLoadedBullet())
                {
                    case PlayerBullets.Bullets.Transmitter:
                        ui.ChangeSpriteOpacity("ammo1", 0);
                        ui.ChangeSpriteOpacity("ammo2", 1);
                        ui.ChangeSpriteOpacity("ammo3", 0);
                        break;
                    case PlayerBullets.Bullets.Agressive:
                        ui.ChangeSpriteOpacity("ammo1", 0);
                        ui.ChangeSpriteOpacity("ammo2", 0);
                        ui.ChangeSpriteOpacity("ammo3", 1);
                        break;
                    case PlayerBullets.Bullets.Paralysis:
                        ui.ChangeSpriteOpacity("ammo1", 1);
                        ui.ChangeSpriteOpacity("ammo2", 0);
                        ui.ChangeSpriteOpacity("ammo3", 0);
                        break;
                    default:
                        ui.ChangeSpriteOpacity("ammo1", 0);
                        ui.ChangeSpriteOpacity("ammo2", 0);
                        ui.ChangeSpriteOpacity("ammo3", 0);
                        break;
                }
            }

        }

        public override void Draw()
        {
            lightRenderer.Draw();

            if (postEffect != null)
                graphics.GraphicsDevice.SetRenderTarget(sceneRenderTarget2D);
            graphics.GraphicsDevice.Clear(Color.LightBlue);
            foreach (GameObject go in gameObjects)
            {
                go.Draw(mainCam);
                //if(go.GetComponent<BoxCollider>() != null)
                //go.GetComponent<BoxCollider>().Draw(projection,graphics, mainCam.view);
            }
            //EnemyWalkingSpots.getInstance().Draw();
            if (postEffect != null)
                postProcessRenderer.Draw(sceneRenderTarget2D);

            ui.Draw();
            //crate.crateModel.GetComponent<BoxCollider>().Draw(projection, graphics, mainCam.view);
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
